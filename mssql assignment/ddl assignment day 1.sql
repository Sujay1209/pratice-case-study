CREATE DATABASE EventDb;
GO

USE EventDb;
GO

CREATE TABLE UserInfo (
    EmailId VARCHAR(100) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Participant')),
    Password VARCHAR(20) NOT NULL CHECK (LEN(Password) BETWEEN 6 AND 20)
);

CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,
    EventName VARCHAR(50) NOT NULL,
    EventCategory VARCHAR(50) NOT NULL,
    EventDate DATETIME NOT NULL,
    Description VARCHAR(50) NULL,
    Status VARCHAR(20) NOT NULL CHECK (Status IN ('Active', 'In-Active'))
);

CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,
    SpeakerName VARCHAR(50) NOT NULL
);
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,
    EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL FOREIGN KEY REFERENCES SpeakersDetails(SpeakerId),
    Description VARCHAR(MAX) NULL,
    SessionStart DATETIME NOT NULL,
    SessionEnd DATETIME NOT NULL,
    SessionUrl VARCHAR(MAX) NULL
);
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,
    ParticipantEmailId VARCHAR(100) NOT NULL FOREIGN KEY REFERENCES UserInfo(EmailId),
    EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
    SessionId INT NOT NULL FOREIGN KEY REFERENCES SessionInfo(SessionId),
    IsAttended BIT NOT NULL CHECK (IsAttended IN (0, 1))
);


