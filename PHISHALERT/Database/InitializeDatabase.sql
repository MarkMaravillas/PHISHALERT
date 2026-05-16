-- Create database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PhishAlertDB')
BEGIN
	CREATE DATABASE PhishAlertDB;
END
GO

-- Use the PhishAlertDB database
USE PhishAlertDB;
GO

-- Create Users table if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
	CREATE TABLE Users
	(
		UserId INT PRIMARY KEY IDENTITY(1,1),
		Username NVARCHAR(100) NOT NULL UNIQUE,
		Email NVARCHAR(255) NOT NULL UNIQUE,
		PasswordHash NVARCHAR(MAX) NOT NULL,
		CreatedAt DATETIME DEFAULT GETDATE(),
		UpdatedAt DATETIME DEFAULT GETDATE()
	);

	-- Create index on Email for faster lookups
	CREATE INDEX IDX_Users_Email ON Users(Email);

	-- Create index on Username for faster lookups
	CREATE INDEX IDX_Users_Username ON Users(Username);
END
GO

-- If Users table exists but doesn't have Email column, add it
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'Email')
	BEGIN
		ALTER TABLE Users ADD Email NVARCHAR(255) NULL;
		ALTER TABLE Users ADD CONSTRAINT UQ_Users_Email UNIQUE (Email);
	END
END
GO
