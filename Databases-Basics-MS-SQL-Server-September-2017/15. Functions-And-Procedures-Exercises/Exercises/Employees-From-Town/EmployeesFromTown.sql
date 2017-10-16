USE SoftUni

GO

CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(50)
AS
SELECT FirstName, LastName FROM Employees AS e
WHERE @townName =
(
	SELECT [Name] FROM Towns
	WHERE TownID =
	(
		SELECT TownID FROM Addresses
		WHERE AddressID = e.AddressID
	)
)