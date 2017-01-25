USE People

CREATE TABLE People(
	Id bigint IDENTITY,
	Name nvarchar(200) NOT NULL,
	Picture varbinary(max),
	Height numeric(3, 2),
	Weight float(2),
	Gender varchar(1) NOT NULL CHECK(gender in('f', 'm')),
	Birthday date NOT NULL,
	Biography ntext
)

ALTER TABLE People 
ADD CONSTRAINT PK_People PRIMARY KEY(Id)
ALTER TABLE People
ADD CONSTRAINT CK_Picture_People CHECK(DATALENGTH(Picture) < 2 * 1024 * 1024)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES
('Adrian Yordanov', NULL, 1.80, 65, 'm', '1997-07-25', 'C# Developer'),
('Petur Petkov', NULL, NULL, NULL, 'm', '1995-03-19', 'JAVA Developer'),
('Petya Raykova', NULL, 1.60, 56, 'f', '1986-07-25', 'C++ Developer'),
('Ivan Raykov', NULL, 1.90, 120, 'm', '1984-04-12', 'SQL Developer'),
('Tihomir Ivanov', NULL, 2, 100, 'm', '1999-09-4', 'HTML/CSS DEVELOPER')