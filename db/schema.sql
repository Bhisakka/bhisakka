-- ============================================================================
-- Bhisakka - Ayurvedic Clinic Management System
-- PostgreSQL Database Schema
-- ============================================================================
-- Target: PostgreSQL 13+ (uses GENERATED ALWAYS AS IDENTITY and generated
-- columns; no extensions required).
--
-- Conventions:
--   * snake_case identifiers (unquoted, so no case-sensitivity headaches
--     in Npgsql queries). Issue names map 1:1, e.g. AudioSchedules ->
--     audio_schedules.
--   * Surrogate integer PKs via GENERATED ALWAYS AS IDENTITY.
--   * Money columns are NUMERIC(10,2). Never float.
--   * "Enums" are TEXT + CHECK constraints (simpler for Npgsql than
--     CREATE TYPE, and still validated by the database).
--   * Timestamps are TIMESTAMPTZ; clock times of day are TIME.
--   * day_of_week uses 0 = Sunday .. 6 = Saturday, matching .NET's
--     System.DayOfWeek so C# code needs no translation.
--
-- Run with:  psql -d bhisakka -f schema.sql
-- ============================================================================

BEGIN;

-- ============================================================================
-- 1. AUTH & STAFF  (Issue #10: staff login & role authentication)
-- ============================================================================

CREATE TABLE roles (
    role_id     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    role_name   TEXT NOT NULL UNIQUE   -- seeded: Doctor, Receptionist, Pharmacist
);

COMMENT ON TABLE roles IS 'Staff roles for role-based access control (feature set 1 §5).';

CREATE TABLE users (
    user_id       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    username      TEXT NOT NULL UNIQUE,
    password_hash TEXT NOT NULL,          -- SHA-256 hex of the password; NEVER store plaintext
    full_name     TEXT NOT NULL,
    role_id       INT  NOT NULL REFERENCES roles (role_id),
    is_active     BOOLEAN NOT NULL DEFAULT TRUE,
    created_at    TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON COLUMN users.password_hash IS
    'Lowercase hex SHA-256 of the password. Compute in C# with SHA256.HashData + Convert.ToHexString(...).ToLower(). Compare hashes, never plaintext.';

-- ============================================================================
-- 2. PATIENTS  (Issue #8: patient registration & demographics)
-- ============================================================================

CREATE TABLE patients (
    patient_id     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    first_name     TEXT NOT NULL,
    last_name      TEXT NOT NULL,
    date_of_birth  DATE,                  -- age is computed, not stored (it goes stale)
    gender         TEXT CHECK (gender IN ('Male', 'Female', 'Other')),
    contact_number TEXT,
    address        TEXT,
    created_at     TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_at     TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON COLUMN patients.date_of_birth IS
    'UI shows age via: date_part(''year'', age(date_of_birth)) or computed in C#.';

-- ============================================================================
-- 3. SCHEDULING ENGINE  (Issue #3: schedule engine, Issue #9: booking;
--    feature set 2 §1: working hours, automated breaks, sudden blocks,
--    rolling 3-day booking window)
-- ============================================================================

CREATE TABLE app_settings (
    setting_key   TEXT PRIMARY KEY,
    setting_value TEXT NOT NULL,
    description   TEXT
);

COMMENT ON TABLE app_settings IS
    'Key/value clinic configuration. Includes booking_window_days = 3 (the rolling window is enforced in application logic; the limit lives here so it is configurable).';

CREATE TABLE schedule_templates (
    template_id           INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    day_of_week           SMALLINT NOT NULL CHECK (day_of_week BETWEEN 0 AND 6),  -- 0=Sunday .. 6=Saturday (.NET DayOfWeek)
    block_type            TEXT NOT NULL CHECK (block_type IN ('Consultation', 'Break')),
    label                 TEXT NOT NULL,  -- e.g. 'Morning Session', 'Breakfast Break'
    start_time            TIME NOT NULL,
    end_time              TIME NOT NULL,
    slot_duration_minutes SMALLINT CHECK (slot_duration_minutes IN (15, 30)),
    is_active             BOOLEAN NOT NULL DEFAULT TRUE,
    CHECK (end_time > start_time),
    -- Consultation blocks must define a slot size; breaks must not.
    CHECK ( (block_type = 'Consultation' AND slot_duration_minutes IS NOT NULL)
         OR (block_type = 'Break'        AND slot_duration_minutes IS NULL) )
);

COMMENT ON TABLE schedule_templates IS
    'The doctor''s recurring daily routine: bookable consultation blocks and un-bookable breaks. ScheduleManager generates concrete 15/30-min slots from these.';

CREATE TABLE blocked_slots (
    blocked_slot_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    block_date      DATE NOT NULL,
    start_time      TIME NOT NULL,
    end_time        TIME NOT NULL,
    reason          TEXT,
    created_by      INT REFERENCES users (user_id),
    created_at      TIMESTAMPTZ NOT NULL DEFAULT now(),
    CHECK (end_time > start_time)
);

COMMENT ON TABLE blocked_slots IS
    'One-off "sudden blocks" (emergency breaks) for a specific date, on top of the recurring template (feature set 2: Dynamic Availability).';

CREATE TABLE appointments (
    appointment_id   INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    patient_id       INT NOT NULL REFERENCES patients (patient_id),
    appointment_date DATE NOT NULL,
    start_time       TIME NOT NULL,
    end_time         TIME NOT NULL,
    status           TEXT NOT NULL DEFAULT 'Scheduled'
                     CHECK (status IN ('Scheduled', 'Waiting', 'InProgress',
                                       'Completed', 'Cancelled', 'NoShow')),
    queue_number     INT,               -- assigned at check-in; drives the live queue order
    booked_by        INT REFERENCES users (user_id),
    created_at       TIMESTAMPTZ NOT NULL DEFAULT now(),
    CHECK (end_time > start_time)
);

COMMENT ON COLUMN appointments.status IS
    'Lifecycle: Scheduled -> Waiting (checked in) -> InProgress -> Completed; or Cancelled / NoShow. Matches QueueManager states in Issue #5.';

-- Single-doctor clinic: one appointment per slot. Cancelled appointments free the slot.
CREATE UNIQUE INDEX uq_appointments_slot
    ON appointments (appointment_date, start_time)
    WHERE status <> 'Cancelled';

CREATE INDEX idx_appointments_patient ON appointments (patient_id);
CREATE INDEX idx_appointments_date    ON appointments (appointment_date);

-- ============================================================================
-- 4. CONSULTATIONS & MEDICAL RECORDS
--    (Issue #5: queue & workspace, Issue #7: history, Issue #2: audio auditing)
-- ============================================================================

CREATE TABLE consultations (
    consultation_id  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    appointment_id   INT NOT NULL UNIQUE REFERENCES appointments (appointment_id),
    patient_id       INT NOT NULL REFERENCES patients (patient_id),
    doctor_id        INT NOT NULL REFERENCES users (user_id),
    started_at       TIMESTAMPTZ NOT NULL DEFAULT now(),
    ended_at         TIMESTAMPTZ,
    diagnosis        TEXT,
    notes            TEXT,               -- the rich-text consultation notes (Issue #5)
    consultation_fee NUMERIC(10,2) NOT NULL DEFAULT 0 CHECK (consultation_fee >= 0)
);

COMMENT ON TABLE consultations IS
    'One row per completed doctor visit. This is the single source of truth behind the ConsultationNotes / MedicalRecord / ConsultationHistory concepts in the issues; per-patient history is the v_consultation_history view.';

CREATE INDEX idx_consultations_patient ON consultations (patient_id);

CREATE TABLE audio_logs (
    audio_log_id     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    consultation_id  INT NOT NULL REFERENCES consultations (consultation_id),
    file_path        TEXT NOT NULL,      -- local disk path ONLY; the audio itself is never stored in the DB
    started_at       TIMESTAMPTZ,
    duration_seconds INT CHECK (duration_seconds >= 0),
    created_at       TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON TABLE audio_logs IS
    'Consultation liability recordings (feature set 1 §2). Stores the local file path, not the audio blob.';

CREATE INDEX idx_audio_logs_consultation ON audio_logs (consultation_id);

-- ============================================================================
-- 5. PHARMACY & INVENTORY  (Issue #6: pharmacy catalog; feature set 1 §3)
-- ============================================================================

CREATE TABLE medicines (
    medicine_id       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name              TEXT NOT NULL UNIQUE,
    medicine_type     TEXT NOT NULL
                      CHECK (medicine_type IN ('Arishta', 'Churna', 'Kashaya',
                                               'Thaila', 'Guli', 'Other')),
    alcohol_content   NUMERIC(5,2) CHECK (alcohol_content BETWEEN 0 AND 100),  -- Arishta-specific (self-generated alcohol %)
    unit              TEXT NOT NULL,     -- e.g. 'bottle (450ml)', 'packet (100g)'
    unit_price        NUMERIC(10,2) NOT NULL CHECK (unit_price >= 0),
    quantity_in_stock INT NOT NULL DEFAULT 0 CHECK (quantity_in_stock >= 0),
    reorder_level     INT NOT NULL DEFAULT 10 CHECK (reorder_level >= 0),
    expiry_date       DATE,
    description       TEXT,
    is_active         BOOLEAN NOT NULL DEFAULT TRUE,
    created_at        TIMESTAMPTZ NOT NULL DEFAULT now(),
    updated_at        TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON COLUMN medicines.medicine_type IS
    'Single-table inheritance: mirrors the C# Medicine base class with Arishta/Churna/... subclasses. Type-specific fields (alcohol_content) are nullable.';
COMMENT ON COLUMN medicines.quantity_in_stock IS
    'The CHECK (>= 0) is the database backstop for atomic stock deduction: overdrawing stock inside the billing transaction fails the whole transaction (Issue #4).';

CREATE TABLE prescriptions (
    prescription_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    consultation_id INT NOT NULL REFERENCES consultations (consultation_id),
    prescribed_at   TIMESTAMPTZ NOT NULL DEFAULT now(),
    notes           TEXT,
    is_fulfilled    BOOLEAN NOT NULL DEFAULT FALSE,
    fulfilled_at    TIMESTAMPTZ
);

COMMENT ON TABLE prescriptions IS
    'Created by the doctor in the consultation workspace (Issue #5); fulfilled at billing time, which deducts stock (Issue #4).';

CREATE INDEX idx_prescriptions_consultation ON prescriptions (consultation_id);

CREATE TABLE prescription_items (
    prescription_item_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    prescription_id      INT NOT NULL REFERENCES prescriptions (prescription_id) ON DELETE CASCADE,
    medicine_id          INT NOT NULL REFERENCES medicines (medicine_id),
    quantity             INT NOT NULL CHECK (quantity > 0),
    dosage_instructions  TEXT            -- e.g. '15ml twice daily after meals'
);

CREATE INDEX idx_prescription_items_prescription ON prescription_items (prescription_id);

-- ============================================================================
-- 6. BILLING & REVENUE  (Issue #4; feature set 1 §4)
-- ============================================================================

CREATE TABLE invoices (
    invoice_id       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    consultation_id  INT REFERENCES consultations (consultation_id),  -- NULL for walk-in pharmacy-only sales
    patient_id       INT NOT NULL REFERENCES patients (patient_id),
    invoice_date     TIMESTAMPTZ NOT NULL DEFAULT now(),
    consultation_fee NUMERIC(10,2) NOT NULL DEFAULT 0 CHECK (consultation_fee >= 0),
    subtotal         NUMERIC(10,2) NOT NULL DEFAULT 0 CHECK (subtotal >= 0),   -- sum of line items (pharmacy sales)
    discount         NUMERIC(10,2) NOT NULL DEFAULT 0 CHECK (discount >= 0),
    total_amount     NUMERIC(10,2) NOT NULL CHECK (total_amount >= 0),         -- consultation_fee + subtotal - discount
    payment_status   TEXT NOT NULL DEFAULT 'Pending'
                     CHECK (payment_status IN ('Pending', 'Paid', 'Cancelled')),
    payment_method   TEXT CHECK (payment_method IN ('Cash', 'Card', 'Other')),
    paid_at          TIMESTAMPTZ,
    created_by       INT REFERENCES users (user_id)
);

COMMENT ON COLUMN invoices.total_amount IS 'consultation_fee + subtotal - discount (computed by the Invoice class, validated here as >= 0).';

CREATE INDEX idx_invoices_patient ON invoices (patient_id);
CREATE INDEX idx_invoices_date    ON invoices (invoice_date);

CREATE TABLE invoice_line_items (
    line_item_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    invoice_id   INT NOT NULL REFERENCES invoices (invoice_id) ON DELETE CASCADE,
    medicine_id  INT REFERENCES medicines (medicine_id),
    description  TEXT NOT NULL,          -- snapshot of the medicine name at sale time
    quantity     INT NOT NULL CHECK (quantity > 0),
    unit_price   NUMERIC(10,2) NOT NULL CHECK (unit_price >= 0),  -- snapshot of price at sale time
    line_total   NUMERIC(12,2) GENERATED ALWAYS AS (quantity * unit_price) STORED
);

COMMENT ON COLUMN invoice_line_items.line_total IS 'Generated column: PostgreSQL computes quantity * unit_price automatically.';

CREATE INDEX idx_invoice_line_items_invoice ON invoice_line_items (invoice_id);

CREATE TABLE stock_transactions (
    stock_transaction_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    medicine_id          INT NOT NULL REFERENCES medicines (medicine_id),
    quantity_change      INT NOT NULL CHECK (quantity_change <> 0),  -- negative = stock out, positive = stock in
    transaction_type     TEXT NOT NULL
                         CHECK (transaction_type IN ('Purchase', 'Dispense', 'Adjustment', 'Expired')),
    invoice_id           INT REFERENCES invoices (invoice_id),       -- set when type = 'Dispense'
    created_by           INT REFERENCES users (user_id),
    created_at           TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON TABLE stock_transactions IS
    'Audit trail for every stock movement, so the automatic deduction at billing time (Issue #4) is traceable.';

CREATE INDEX idx_stock_transactions_medicine ON stock_transactions (medicine_id);

-- ============================================================================
-- 7. AMBIANCE AUTOMATION  (Issue #1; feature set 2 §2)
-- ============================================================================

CREATE TABLE audio_schedules (
    audio_schedule_id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    track_name        TEXT NOT NULL,
    file_path         TEXT NOT NULL,     -- local disk path to the audio file
    track_type        TEXT NOT NULL
                      CHECK (track_type IN ('Pirith', 'Puja', 'AmbientMusic', 'Announcement')),
    trigger_time      TIME,              -- daily trigger; NULL = manual-only (e.g. queue announcements)
    is_enabled        BOOLEAN NOT NULL DEFAULT TRUE,
    created_at        TIMESTAMPTZ NOT NULL DEFAULT now()
);

COMMENT ON TABLE audio_schedules IS
    'Daily ambiance playlist evaluated by AudioScheduler (e.g. Thun Suthraya at 04:00). Rows with NULL trigger_time are manually triggered announcements.';

-- ============================================================================
-- 8. VIEWS
-- ============================================================================

-- Issue #7: per-patient visit history ("ConsultationHistory").
-- Filter with: WHERE patient_id = @patientId ORDER BY started_at DESC
CREATE VIEW v_consultation_history AS
SELECT c.patient_id,
       p.first_name || ' ' || p.last_name          AS patient_name,
       c.consultation_id,
       a.appointment_date,
       c.started_at,
       c.ended_at,
       c.diagnosis,
       c.notes,
       c.consultation_fee,
       COALESCE(rx.medicines_prescribed, '(none)') AS medicines_prescribed
FROM consultations c
JOIN patients     p ON p.patient_id     = c.patient_id
JOIN appointments a ON a.appointment_id = c.appointment_id
LEFT JOIN LATERAL (
    SELECT string_agg(m.name || ' x' || pi.quantity, ', ') AS medicines_prescribed
    FROM prescriptions pr
    JOIN prescription_items pi ON pi.prescription_id = pr.prescription_id
    JOIN medicines m           ON m.medicine_id      = pi.medicine_id
    WHERE pr.consultation_id = c.consultation_id
) rx ON TRUE;

-- Issue #6: low-stock / near-expiry alerts.
CREATE VIEW v_low_stock AS
SELECT medicine_id,
       name,
       medicine_type,
       quantity_in_stock,
       reorder_level,
       expiry_date,
       CASE
           WHEN quantity_in_stock <= reorder_level THEN 'LowStock'
           ELSE 'NearExpiry'
       END AS alert_type
FROM medicines
WHERE is_active
  AND (   quantity_in_stock <= reorder_level
       OR expiry_date <= CURRENT_DATE + 30);

-- Issue #4: basic revenue reporting from paid invoices.
CREATE VIEW v_daily_revenue AS
SELECT invoice_date::date       AS revenue_date,
       COUNT(*)                 AS invoice_count,
       SUM(consultation_fee)    AS consultation_revenue,
       SUM(subtotal)            AS pharmacy_revenue,
       SUM(discount)            AS total_discounts,
       SUM(total_amount)        AS total_revenue
FROM invoices
WHERE payment_status = 'Paid'
GROUP BY invoice_date::date;

COMMIT;
