USE Test

CREATE TABLE ItemTypes(
	ItemTypeID int PRIMARY KEY,
	Name varchar(50)
)

CREATE TABLE Items(
	ItemID int PRIMARY KEY,
	Name varchar(50),
	ItemTypeID int FOREIGN KEY references ItemTypes(ItemTypeID)
)

CREATE TABLE Cities(
	CityID int PRIMARY KEY,
	Name varchar(50)
)

CREATE TABLE Customers(
	CustomerID int PRIMARY KEY,
	Name varchar(50),
	Birthday date,
	CityID int FOREIGN KEY references Cities(CityID)
)

CREATE TABLE Orders(
	OrderId int PRIMARY KEY,
	CustomerID int FOREIGN KEY references Customers(CustomerID)
)

CREATE TABLE OrderItems(
	OrderID int FOREIGN KEY references Orders(OrderID),
	ItemID int FOREIGN KEY references Items(ItemID),
	CONSTRAINT PK_OrderID_ItemID
	PRIMARY KEY(OrderID, ItemID)
)