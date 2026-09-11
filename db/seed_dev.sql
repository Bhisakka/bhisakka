-- ============================================================================
-- Bhisakka - Developer demo data (safe to re-run)
-- Adds today's appointments (for the check-in / queue / consultation flow) plus
-- one past completed consultation with a prescription (for Patient History and
-- Billing). Run AFTER schema.sql + seed.sql:
--   psql -d bhisakka -f seed_dev.sql
--
-- Guards make this idempotent: patients are added only if missing, today's
-- appointments only if there are none for today, and the historical
-- consultation only if the consultations table is empty.
-- ============================================================================

BEGIN;

-- ----------------------------------------------------------------------------
-- A couple more patients so the patient list is fuller.
-- ----------------------------------------------------------------------------
INSERT INTO patients (first_name, last_name, date_of_birth, gender, contact_number, address)
SELECT 'Anoma', 'Rajapaksa', DATE '1988-02-14', 'Female', '0771122334', '45, Flower Road, Colombo 07'
WHERE NOT EXISTS (SELECT 1 FROM patients WHERE first_name = 'Anoma' AND last_name = 'Rajapaksa');

INSERT INTO patients (first_name, last_name, date_of_birth, gender, contact_number, address)
SELECT 'Ravindra', 'Kumara', DATE '1972-09-30', 'Male', '0763344556', '17, Hospital Road, Galle'
WHERE NOT EXISTS (SELECT 1 FROM patients WHERE first_name = 'Ravindra' AND last_name = 'Kumara');

-- ----------------------------------------------------------------------------
-- Today's appointments.
--   Two are already 'Waiting' (checked in, queue numbers assigned) so the Live
--   Queue has patients you can Call Next immediately.
--   Three are 'Scheduled' so you can practice the Check-In step yourself.
-- Only inserted when today has no appointments yet.
-- ----------------------------------------------------------------------------
INSERT INTO appointments (patient_id, appointment_date, start_time, end_time, status, queue_number, booked_by)
SELECT p.patient_id, CURRENT_DATE, v.st, v.et, v.status, v.qn,
       (SELECT user_id FROM users WHERE username = 'reception')
FROM (VALUES
    ('Sunil',    'Bandara',    TIME '09:00', TIME '09:15', 'Waiting',   1),
    ('Malini',   'Fernando',   TIME '09:15', TIME '09:30', 'Waiting',   2),
    ('Tharindu', 'Jayasuriya', TIME '09:30', TIME '09:45', 'Scheduled', NULL),
    ('Anoma',    'Rajapaksa',  TIME '09:45', TIME '10:00', 'Scheduled', NULL),
    ('Ravindra', 'Kumara',     TIME '16:00', TIME '16:30', 'Scheduled', NULL)
) AS v(fn, ln, st, et, status, qn)
JOIN patients p ON p.first_name = v.fn AND p.last_name = v.ln
WHERE NOT EXISTS (SELECT 1 FROM appointments WHERE appointment_date = CURRENT_DATE);

-- ----------------------------------------------------------------------------
-- One past, completed consultation (7 days ago) with a prescription, so the
-- Patient History screen shows a visit and the Billing screen shows an
-- unbilled consultation ready to invoice. Only inserted on a fresh DB.
-- ----------------------------------------------------------------------------
WITH new_appt AS (
    INSERT INTO appointments (patient_id, appointment_date, start_time, end_time, status, booked_by)
    SELECT (SELECT patient_id FROM patients WHERE first_name = 'Sunil' AND last_name = 'Bandara'),
           CURRENT_DATE - 7, TIME '09:00', TIME '09:15', 'Completed',
           (SELECT user_id FROM users WHERE username = 'reception')
    WHERE NOT EXISTS (SELECT 1 FROM consultations)
    RETURNING appointment_id, patient_id
),
new_consult AS (
    INSERT INTO consultations (appointment_id, patient_id, doctor_id, started_at, ended_at,
                               diagnosis, notes, consultation_fee)
    SELECT a.appointment_id, a.patient_id,
           (SELECT user_id FROM users WHERE username = 'doctor'),
           (CURRENT_DATE - 7) + TIME '09:00', (CURRENT_DATE - 7) + TIME '09:20',
           'Vata imbalance with joint stiffness',
           'Advised warm oil massage (abhyanga) and dietary changes. Follow up in two weeks.',
           1000.00
    FROM new_appt a
    RETURNING consultation_id
),
new_presc AS (
    INSERT INTO prescriptions (consultation_id, notes, is_fulfilled)
    SELECT consultation_id, 'Take medicines with warm water.', FALSE
    FROM new_consult
    RETURNING prescription_id
)
INSERT INTO prescription_items (prescription_id, medicine_id, quantity, dosage_instructions)
SELECT pr.prescription_id, m.medicine_id, x.qty, x.dose
FROM new_presc pr
CROSS JOIN (VALUES
    ('Triphala Churna',     2, '1 tsp with warm water twice daily after meals'),
    ('Maharasnadi Kashaya', 1, '15ml twice daily before meals')
) AS x(mname, qty, dose)
JOIN medicines m ON m.name = x.mname;

COMMIT;
