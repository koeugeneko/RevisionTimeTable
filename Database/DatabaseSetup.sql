-- TimeTable Database Setup Script for PostgreSQL
-- Run this script to initialize the database

-- Create tables in order (respecting foreign key dependencies)

-- 1. Users table
CREATE TABLE IF NOT EXISTS Users (
    user_id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    user_email VARCHAR(100) UNIQUE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    last_login TIMESTAMP
);

-- 2. UserPasswords table
CREATE TABLE IF NOT EXISTS UserPasswords (
    password_id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES Users(user_id) ON DELETE CASCADE,
    hashed_password VARCHAR(255) NOT NULL,
    salt VARCHAR(50) NOT NULL
);

-- 3. UserSettings table
CREATE TABLE IF NOT EXISTS UserSettings (
    user_id INTEGER PRIMARY KEY REFERENCES Users(user_id) ON DELETE CASCADE,
    max_daily_task INTEGER DEFAULT 5,
    enable_notifications BOOLEAN DEFAULT true,
    volume INTEGER DEFAULT 50,
    region VARCHAR(10) DEFAULT 'en'
);

-- 4. Subjects table
CREATE TABLE IF NOT EXISTS Subjects (
    subject_id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES Users(user_id) ON DELETE CASCADE,
    subject_name VARCHAR(100) NOT NULL,
);

-- 5. Tasks table
CREATE TABLE IF NOT EXISTS Tasks (
    task_id SERIAL PRIMARY KEY,
    subject_id INTEGER REFERENCES Subjects(subject_id) ON DELETE CASCADE,
    name VARCHAR(200) NOT NULL,
    description TEXT,
    estimated_min INTEGER DEFAULT 30,
    priority INTEGER DEFAULT 1,
    due_date DATE,
    completed BOOLEAN DEFAULT false,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    completed_at TIMESTAMP,
    actual_minutes INTEGER
);

-- 6. DailyPlans table
CREATE TABLE IF NOT EXISTS DailyPlans (
    plan_id SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES Users(user_id) ON DELETE CASCADE,
    plan_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(user_id, plan_date)
);

-- 7. DailyPlanTasks table
CREATE TABLE IF NOT EXISTS DailyPlanTasks (
    plan_task_id SERIAL PRIMARY KEY,
    plan_id INTEGER REFERENCES DailyPlans(plan_id) ON DELETE CASCADE,
    task_id INTEGER REFERENCES Tasks(task_id) ON DELETE CASCADE,
    task_order INTEGER,
    UNIQUE(plan_id, task_id)
);

-- Create indexes for performance
CREATE INDEX IF NOT EXISTS idx_tasks_user ON Tasks(subject_id);
CREATE INDEX IF NOT EXISTS idx_tasks_completed ON Tasks(completed);
CREATE INDEX IF NOT EXISTS idx_tasks_due_date ON Tasks(due_date);
CREATE INDEX IF NOT EXISTS idx_subjects_user ON Subjects(user_id);
CREATE INDEX IF NOT EXISTS idx_daily_plans_user ON DailyPlans(user_id);
CREATE INDEX IF NOT EXISTS idx_daily_plans_date ON DailyPlans(plan_date);

-- Comments
COMMENT ON TABLE Users IS 'Stores user account information';
COMMENT ON TABLE UserPasswords IS 'Stores hashed passwords with salt';
COMMENT ON TABLE UserSettings IS 'Stores user preferences and settings';
COMMENT ON TABLE Subjects IS 'Stores subjects created by users';
COMMENT ON TABLE Tasks IS 'Stores tasks associated with subjects';
COMMENT ON TABLE DailyPlans IS 'Stores daily study plans generated for users';
COMMENT ON TABLE DailyPlanTasks IS 'Links tasks to daily plans with ordering';
