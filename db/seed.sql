-- ============================================================================
-- Bhisakka - Seed / Reference Data
-- Run AFTER schema.sql:  psql -d bhisakka -f seed.sql
-- ============================================================================

BEGIN;

-- ----------------------------------------------------------------------------
-- Roles & default logins (Issue #10)
--
-- Development credentials (SHA-256 of the plaintext is stored):
--   doctor    / doctor123
--   reception / reception123
--   pharmacy  / pharmacy123
-- CHANGE THESE before any real deployment.
-- ----------------------------------------------------------------------------

INSERT INTO roles (role_name) VALUES
    ('Doctor'),
    ('Receptionist'),
    ('Pharmacist');

INSERT INTO users (username, password_hash, full_name, role_id) VALUES
    ('doctor',    'f348d5628621f3d8f59c8cabda0f8eb0aa7e0514a90be7571020b1336f26c113',
     'Dr. Vedha Weerasinghe', (SELECT role_id FROM roles WHERE role_name = 'Doctor')),
    ('reception', '5145dba3b6bda2d610d2c5c435a1c2481eefd3146b6a7e004ad73f794386e031',
     'Nimal Perera',          (SELECT role_id FROM roles WHERE role_name = 'Receptionist')),
    ('pharmacy',  'ed5273f7ab1e24f89704b06074e12565a17da3d0457bd9a5271b43816f985d57',
     'Kumari Silva',          (SELECT role_id FROM roles WHERE role_name = 'Pharmacist'));

-- ----------------------------------------------------------------------------
-- Clinic configuration (Issues #3 and #9)
-- ----------------------------------------------------------------------------

INSERT INTO app_settings (setting_key, setting_value, description) VALUES
    ('booking_window_days',       '3',    'Rolling booking window: patients may book at most N days in advance (feature set 2). Next day''s slots open at midnight.'),
    ('clinic_name',               'Bhisakka Ayurvedic Clinic', 'Displayed on forms and printed invoices.'),
    ('default_consultation_fee',  '1000.00', 'Default fee pre-filled on new consultations (LKR).'),
    ('expiry_warning_days',       '30',   'Medicines expiring within N days appear in v_low_stock.');

-- ----------------------------------------------------------------------------
-- Doctor's daily routine (Issue #3; feature set 2 §1)
-- Same template every day of the week (0 = Sunday .. 6 = Saturday).
-- ----------------------------------------------------------------------------

INSERT INTO schedule_templates (day_of_week, block_type, label, start_time, end_time, slot_duration_minutes)
SELECT d, 'Consultation', 'Morning Session',      TIME '06:00', TIME '08:30', 15 FROM generate_series(0, 6) AS d
UNION ALL
SELECT d, 'Break',        'Breakfast Break',      TIME '08:30', TIME '09:00', NULL FROM generate_series(0, 6) AS d
UNION ALL
SELECT d, 'Consultation', 'Late Morning Session', TIME '09:00', TIME '11:30', 15 FROM generate_series(0, 6) AS d
UNION ALL
SELECT d, 'Break',        'Lunch & Rest',         TIME '11:30', TIME '16:00', NULL FROM generate_series(0, 6) AS d
UNION ALL
SELECT d, 'Consultation', 'Evening Session',      TIME '16:00', TIME '18:30', 30 FROM generate_series(0, 6) AS d;

-- ----------------------------------------------------------------------------
-- Pharmacy catalog (Issue #6)
-- 'Herbal Honey' is deliberately under its reorder level so v_low_stock
-- has a row to show during testing.
-- ----------------------------------------------------------------------------

INSERT INTO medicines (name, medicine_type, alcohol_content, unit, unit_price, quantity_in_stock, reorder_level, expiry_date, description) VALUES
    ('Ashwagandharishta',    'Arishta', 7.50, 'bottle (450ml)',     850.00, 40, 10, CURRENT_DATE + 540, 'Nervine tonic; self-generated alcohol from fermentation.'),
    ('Dasamoolarishta',      'Arishta', 6.00, 'bottle (450ml)',     900.00, 35, 10, CURRENT_DATE + 540, 'Post-natal care and general debility.'),
    ('Triphala Churna',      'Churna',  NULL, 'packet (100g)',      350.00, 60, 15, CURRENT_DATE + 365, 'Digestive and detox powder blend.'),
    ('Sitopaladi Churna',    'Churna',  NULL, 'packet (100g)',      420.00, 50, 15, CURRENT_DATE + 365, 'Respiratory support powder.'),
    ('Maharasnadi Kashaya',  'Kashaya', NULL, 'bottle (450ml)',     780.00, 25, 10, CURRENT_DATE + 180, 'Decoction for joint and nerve conditions.'),
    ('Kesharaja Thaila',     'Thaila',  NULL, 'bottle (100ml)',     650.00, 30, 10, CURRENT_DATE + 720, 'Medicated hair oil.'),
    ('Chandraprabha Guli',   'Guli',    NULL, 'bottle (60 pills)', 1200.00, 45, 10, CURRENT_DATE + 720, 'Classical pill for urinary and metabolic support.'),
    ('Herbal Honey',         'Other',   NULL, 'jar (250g)',         550.00,  3,  5, CURRENT_DATE + 270, 'Vehicle (anupana) for churna doses.');

-- ----------------------------------------------------------------------------
-- Ambiance playlist (Issue #1; feature set 2 §2)
-- trigger_time NULL = manual-only announcement.
-- ----------------------------------------------------------------------------

INSERT INTO audio_schedules (track_name, file_path, track_type, trigger_time) VALUES
    ('Thun Suthraya (Morning Pirith)', 'C:\Bhisakka\Audio\thun_suthraya.mp3',      'Pirith',       TIME '04:00'),
    ('Ayurvedic Ambient Music',        'C:\Bhisakka\Audio\ambient_morning.mp3',    'AmbientMusic', TIME '09:00'),
    ('Evening Buddha Puja',            'C:\Bhisakka\Audio\evening_puja.mp3',       'Puja',         TIME '18:00'),
    ('Queue Announcement Chime',       'C:\Bhisakka\Audio\queue_announcement.mp3', 'Announcement', NULL);

-- ----------------------------------------------------------------------------
-- Sample patients (Issue #8) so booking/queue screens have data.
-- ----------------------------------------------------------------------------

INSERT INTO patients (first_name, last_name, date_of_birth, gender, contact_number, address) VALUES
    ('Sunil',   'Bandara',   DATE '1965-03-12', 'Male',   '0712345678', '24, Temple Road, Kandy'),
    ('Malini',  'Fernando',  DATE '1978-11-02', 'Female', '0779876543', '8/1, Lake View, Kurunegala'),
    ('Tharindu','Jayasuriya',DATE '1994-06-25', 'Male',   '0705551234', '112, Main Street, Matale');

COMMIT;
