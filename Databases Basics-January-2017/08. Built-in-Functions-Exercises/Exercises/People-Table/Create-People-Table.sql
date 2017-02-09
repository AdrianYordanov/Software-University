USE Test

CREATE TABLE People(
	Id int PRIMARY KEY IDENTITY,
	Name varchar(50),
	Birthdate datetime
)

INSERT INTO People VALUES
('Adrian Yordanov', '1997-07-25'),
('Petur Stoyanov', '1973-12-22'),
('Ivan Petrov', '1999-07-15'),
('Tihmor Ivanov', '1982-04-02'),
('Rosen Tihomirov', '1992-03-25'),
('Trayan Stoilov', '2001-08-30')