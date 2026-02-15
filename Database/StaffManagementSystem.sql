CREATE DATABASE StaffManagementSystem;
GO

USE StaffManagementSystem;
GO

CREATE TABLE Staff (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IndexNumber NVARCHAR(50) UNIQUE NOT NULL,
    FullNames NVARCHAR(200) NOT NULL,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    CurrentLocation NVARCHAR(150),
    HighestLevelOfEducation NVARCHAR(150),
    DutyStation NVARCHAR(150),
    AvailabilityForRemoteWork BIT,
    SoftwareExpertise NVARCHAR(150),
    SoftwareExpertiseLevel NVARCHAR(100),
    Language NVARCHAR(100),
    LevelOfResponsibility NVARCHAR(100)
);
