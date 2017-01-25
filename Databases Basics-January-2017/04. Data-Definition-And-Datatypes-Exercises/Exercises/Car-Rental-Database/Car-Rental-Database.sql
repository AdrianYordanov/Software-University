USE CarRental

CREATE TABLE Categories(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	Category varchar(20) NOT NULL,
	DailyRate money NOT NULL,
	WeeklyRate money NOT NULL,
	MonthlyRate money NOT NULL,
	WeekendRate money NOT NULL,
)
INSERT INTO Categories(Category, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Jeeps', 30, 100, 260, 40),
('Cars', 20, 80, 240, 15),
('Sport cars', 50, 200, 500, 80);

CREATE TABLE Cars(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	PlateNumber nvarchar(8) NOT NULL,
	Make varchar(20) NOT NULL,
	CarYear int NOT NULL,
	CategoryId int NOT NULL,
	Doors int NOT NULL,
	Picture varbinary(max),
	Condition text NOT NULL,
	Available bit NOT NULL
)
INSERT INTO Cars(PlateNumber, Make, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('ÅÂ2000ÂÀ', 'Germany', 2010, 1, 4, NULL, 'Offroad djeep.', 1),
('ÑÂ7777ÂÀ', 'Italy', 2015, 3, 4, NULL, 'Very fast car.', 1),
('ÂÀ6484ÂÀ', 'Germany', 2013, 2, 2, NULL, 'Regular city.', 1);

CREATE TABLE Employees(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Notes ntext
)
INSERT INTO Employees(FirstName, LastName, Notes)
VALUES
('Adrian', 'Yordanov', 'The boss.'),
('Peter', 'Stoyanov', NULL),
('Ivan', 'Petrov', NULL);

CREATE TABLE Customers(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	DriverLicenseNumber int NOT NULL,
	FullName nvarchar(40) NOT NULL,
	Adress ntext NOT NULL,
	City ntext NOT NULL,
	ZipCode int NOT NULL,
	Notes ntext
)
INSERT INTO Customers(DriverLicenseNumber, FullName, Adress, City, ZipCode, Notes)
VALUES
(5356316, 'Tihomir Stanev', 'Sofia Center', 'Sofia', 1000, NULL),
(9693713, 'Yoan Botev', 'Sofia Center', 'Sofia', 1000, NULL),
(1475439, 'Rositsa Maneva', 'Sofia Center', 'Sofia', 1000, NULL)

CREATE TABLE RentalOrders(
	Id int NOT NULL IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL,
	CustomerId int NOT NULL,
	CarId int NOT NULL,
	CarCondition text NOT NULL,
	TankLevel int NOT NULL,
	KilometrageStart int NOT NULL,
	KilometrageEnd int NOT NULL,
	TotalKilometrage int NOT NULL,	
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	TotalDays int NOT NULL,
	RateReplied money NOT NULL,
	TaxRate money NOT NULL,
	OrderStatus bit NOT NULL,
	Notes ntext
)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, CarCondition, TankLevel, KilometrageStart,
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateReplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 'Offroad djeep.', 80, 400, 600, 200, '2017-01-02', '2017-02-02', 31, 260, 10, 1, 'Good client.'),
(1, 1, 1, 'Very fast car.', 80, 400, 600, 200, '2017-01-02', '2017-02-02', 31, 260, 10, 1, 'Good client.'),
(1, 1, 1, 'Regular car.', 80, 400, 600, 200, '2017-01-02', '2017-02-02', 31, 260, 10, 1, 'Good client.');