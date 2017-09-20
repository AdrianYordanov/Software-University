USE Minions

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) CHECK (Gender IN('m', 'f')) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NTEXT
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Adrian', NULL, 1.80, 65.00, 'm', '1997-07-25', 'C# Web Developer'),
('Peter', NULL, 2.10, 76.30, 'm', '1994-07-02', NULL),
('George', NULL, 1.72, 120.00, 'm', '1993-09-12', 'Java Web Developer'),
('Ivan', NULL, 1.79, 89.30, 'm', '1998-08-29', NULL),
('Stamat', NULL, 1.84, 90.35, 'm', '1995-01-25', 'Python Web Developer')