USE Softuni

CREATE TABLE Towns(
	Id int IDENTITY NOT NULL,
	Name varchar(30) NOT NULL
)
ALTER TABLE Towns
ADD CONSTRAINT PK_Towns
PRIMARY KEY(Id)

CREATE TABLE Adresses(
	Id int IDENTITY NOT NULL,
	AdressText varchar(50) NOT NULL,
	TownId int NOT NULL
)
ALTER TABLE Adresses
ADD CONSTRAINT PK_Adresses
PRIMARY KEY(Id)
ALTER TABLE Adresses
ADD CONSTRAINT FK_TownId_Adresses
FOREIGN KEY (TownId) REFERENCES Towns(Id)

CREATE TABLE Departments(
	Id int IDENTITY NOT NULL,
	Name varchar(30) NOT NULL,
)
ALTER TABLE Departments
ADD CONSTRAINT PK_Departments
PRIMARY KEY(Id)

CREATE TABLE Employees(
	Id int IDENTITY NOT NULL,
	FirstName varchar(20) NOT NULL,
	MiddleName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	JobTitle varchar(20) NOT NULL,
	DepartmentId int NOT NULL,
	HireDate date NOT NULL,
	Salary money NOT NULL,
	AdressId int
)
ALTER TABLE Employees
ADD CONSTRAINT PK_Employees
PRIMARY KEY(Id)
ALTER TABLE Employees
ADD CONSTRAINT FK_DepartmentId_Employees
FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
ALTER TABLE	Employees
ADD CONSTRAINT FK_AdressId_Employees
FOREIGN KEY (AdressId) REFERENCES Adresses(Id)