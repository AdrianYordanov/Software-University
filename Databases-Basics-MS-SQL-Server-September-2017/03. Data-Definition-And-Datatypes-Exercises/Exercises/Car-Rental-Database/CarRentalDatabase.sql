USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY, 
	CategoryName VARCHAR(50) NOT NULL, 
	DailyRate DECIMAL(4, 2) NOT NULL, 
	WeeklyRate DECIMAL(5, 2) NOT NULL, 
	MonthlyRate DECIMAL(6, 2) NOT NULL, 
	WeekendRate DECIMAL(5, 2) NOT NULL,
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber CHAR(8) NOT NULL, 
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL, 
	CarYear INT NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
	Doors INT NOT NULL,
	Picture VARBINARY(MAX), 
	Condition VARCHAR(50) NOT NULL, 
	Available BIT NOT NULL,
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL, 
	Title VARCHAR(50) NOT NULL, 
	Notes NTEXT
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber CHAR(5) NOT NULL, 
	FullName VARCHAR(100) NOT NULL, 
	[Address] VARCHAR(200) NOT NULL,
	City VARCHAR(50) NOT NULL, 
	ZIPCode CHAR(4) NOT NULL, 
	Notes NTEXT
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(5, 2) NOT NULL, 
	KilometrageStart DECIMAL NOT NULL, 
	KilometrageEnd DECIMAL NOT NULL, 
	TotalKilometrage DECIMAL NOT NULL, 
	StartDate DATE NOT NULL, 
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied BIT NOT NULL,
	TaxRate DECIMAL NOT NULL, 
	OrderStatus BIT NOT NULL,
	Notes NTEXT
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
('Car', 50, 400, 1000, 75),
('Jeap', 60, 420, 1500, 100),
('Motor', 30, 150, 1200, 50)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
('CB2013BA', 'Germany', 'Mercedes C', 2006, 1, 4, NULL, 'Excellent', 1),
('CB2014BA', 'Germany', 'Mercedes E', 2002, 2, 4, NULL, 'Excellent', 0),
('CB2015BA', 'Germany', 'Mercedes B', 2008, 3, 4, NULL, 'Excellent', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES
('Adrian', 'Yordanov', 'Adrians Title', NULL),
('Gabriel', 'Boykinov', 'Gabriels Title', NULL),
('Ivaylo', 'Mitev', 'Ivaylos Title', NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes)
VALUES
('B2JG6', 'Plamen Kamenov', 'gr Gabrovo, koleloto', 'Gabrovo', 5300, NULL),
('B2JG6', 'Rumen Atanasov', 'gr Gabrovo, krushata', 'Gabrovo', 5300, NULL),
('B2JG6', 'Stanislav Tinchev', 'gr Gabrovo, palauzovo', 'Gabrovo', 5300, NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES
(1, 1, 1, 70, 400, 700, 300, '2017-01-05', '2017-01-10', 5, 1, 40, 1, NULL),
(2, 2, 2, 70, 400, 700, 300, '2017-01-05', '2017-01-10', 5, 1, 30, 0, NULL),
(3, 3, 3, 70, 400, 700, 300, '2017-01-05', '2017-01-10', 5, 1, 60, 0, NULL)