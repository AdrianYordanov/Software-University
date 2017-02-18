USE Test

CREATE TABLE Persons(
	PersonId int IDENTITY,
	FirstName varchar(50),
	Salary money,
	PassportID int UNIQUE NOT NULL
)

CREATE TABLE Passports(
	PassportID int IDENTITY(101, 1),
	PassportNumber varchar(8)
)

ALTER TABLE Persons
ADD PRIMARY KEY(PersonID)

ALTER TABLE Passports
ADD PRIMARY KEY(PassportID)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID) references Passports(PassportID)

INSERT INTO Passports
VALUES 
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons
VALUES 
('Roberto', 43300, 102),
('Tom', 56100, 103), 
('Yana', 60200, 101)