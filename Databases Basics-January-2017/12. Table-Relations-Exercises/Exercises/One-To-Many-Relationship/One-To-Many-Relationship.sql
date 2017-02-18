USE Test

CREATE TABLE Manufacturers(
	ManufacturerID int PRIMARY KEY IDENTITY,
	Name varchar(50),
	EstablishedOn date
)

CREATE TABLE Models(
	ModelID int PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50),
	ManufacturerID int FOREIGN KEY references Manufacturers(ManufacturerId)
)

INSERT INTO Manufacturers
VALUES 
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'), 
('Lada', '1966-05-01')

INSERT INTO Models
VALUES 
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)