USE SoftUni

GO

CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(10)
AS
SELECT FirstName, LastName FROM Employees AS e
WHERE (SELECT dbo.ufn_GetSalaryLevel(e.Salary)) = @salaryLevel