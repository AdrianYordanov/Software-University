USE SoftUni

GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber @checkSalary DECIMAL(18,4)
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @checkSalary