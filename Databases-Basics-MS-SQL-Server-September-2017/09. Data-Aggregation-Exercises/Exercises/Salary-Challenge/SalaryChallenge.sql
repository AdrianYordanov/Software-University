USE SoftUni

SELECT TOP (10) FirstName, LastName, DepartmentID 
FROM Employees AS e
WHERE Salary > 
(
	SELECT AVG(Salary) [AverageSalary] 
	FROM Employees
	WHERE DepartmentID = e.DepartmentID
	GROUP BY DepartmentID
)
ORDER BY DepartmentID