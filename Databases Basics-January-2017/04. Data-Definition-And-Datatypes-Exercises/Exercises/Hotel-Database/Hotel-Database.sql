USE Hotel

CREATE TABLE Employees(
	ID int IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Title nvarchar(50) NOT NULL,
	Notes ntext
)
INSERT INTO Employees(FirstName, LastName, Title, Notes) 
VALUES
('Adrian', 'Yardonov', 'boss', 'Gives instructions to everybody.'),
('Tihomir', 'Toshev', 'cleaner', NULL),
('Pesho', 'Stratev', 'reception', NULL);
 
CREATE TABLE Customers(
	AccountNumber int IDENTITY PRIMARY KEY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	PhoneNumber varchar(15) NOT NULL,
	EmergencyName nvarchar(20),
	EmergencyNumber nvarchar(20),
	Notes ntext
)
INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) 
VALUES
('Galin', 'Petkov', '0876546251', NULL, NULL, 'New guest.'),
('Nikolay', 'Stoyanov', '0875543358', NULL, NULL, NULL),
('Kiril', 'Hristov', '0876396135', NULL, NULL, NULL);
 
CREATE TABLE RoomStatus(
	RoomStatus int IDENTITY PRIMARY KEY NOT NULL,
	Notes text NOT NULL,
)
INSERT INTO RoomStatus(Notes)
VALUES
('Free'),
('Reserved'),
('Upgrading');
 
CREATE TABLE RoomTypes(
	RoomType int IDENTITY PRIMARY KEY NOT NULL,
	Notes ntext NOT NULL
)
INSERT INTO RoomTypes(Notes)
VALUES
('Small'),
('Large'),
('President');
 
CREATE TABLE BedTypes(
	BedType int IDENTITY PRIMARY KEY,
	Notes ntext
)
INSERT INTO BedTypes(Notes)
VALUES
('One bed'),
('Two beds'),
('Bedroom');
 
CREATE TABLE Rooms(
	RoomNumber int IDENTITY PRIMARY KEY,
	RoomType nvarchar(50) NOT NULL,
	BedType nvarchar(50) NOT NULL,
	Rate money NOT NULL,
	RoomStatus int NOT NULL,
	Notes ntext
)
INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
(1, 1, 200, 1, NULL),
(2, 2, 250, 2, NULL),
(3, 3, 300, 3, NULL);

CREATE TABLE Payments(
	ID int IDENTITY PRIMARY KEY,
	EmployeeID int NOT NULL,
	PaymentDate date NOT NULL,
	AccountNumber int NOT NULL,
	FirstDateOccupied date NOT NULL,
	LastDateOccupied date NOT NULL,
	TotalDays int NOT NULL,
	AmountCharged money NOT NULL,
	TaxRate money NOT NULL,
	TaxAmount money NOT NULL,
	PaymentTotal money NOT NULL,
	Notes ntext
)
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) 
VALUES
(1, GETDATE(), 1, GETDATE(), GETDATE(), 2, 200, 50, 50, 300, NULL),
(2, GETDATE(), 2, GETDATE(), GETDATE(), 2, 200, 50, 50, 300, NULL),
(3, GETDATE(), 3, GETDATE(), GETDATE(), 2, 200, 50, 50, 300, NULL);
 
CREATE TABLE Occupancies(
ID int IDENTITY(1,1) PRIMARY KEY,
EmployeeID int NOT NULL,
DateOccupied date NOT NULL,
AccountNumber int NOT NULL,
RoomNumber int NOT NULL,
RateApplied money NOT NULL,
PhoneCharge bit NOT NULL,
Notes ntext
)
INSERT INTO Occupancies(EmployeeID, DateOccupied, AccountNumber, 
RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1, GETDATE(), 1, 1, 200, 1, NULL),
(1, GETDATE(), 1, 1, 200, 1, NULL),
(1, GETDATE(), 1, 1, 200, 1, NULL);