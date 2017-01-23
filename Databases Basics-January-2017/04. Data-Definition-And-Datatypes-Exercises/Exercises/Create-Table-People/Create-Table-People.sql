USE People
CREATE TABLE People(
	Id bigint IDENTITY PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	Picture binary(2000),
	Height numeric(3, 2),
	Weight float(2),
	Gender varchar(1) NOT NULL,
	Birthday date NOT NULL,
	Biography ntext
)
INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES
('Adrian Yordanov', NULL, 1.80, 65, 'm', '1997-07-25', 'C# Developer'),
('Petur Petkov', NULL, NULL, NULL, 'm', '1995-03-19', NULL),
('Petya Raykova', NULL, 1.60, 56, 'f', '1986-07-25', NULL),
('Ivan Raykov', NULL, 1.90, 120, 'm', '1984-04-12', NULL),
('Tihomir Ivanov', NULL, 2, 100, 'm', '1999-09-4', NULL)