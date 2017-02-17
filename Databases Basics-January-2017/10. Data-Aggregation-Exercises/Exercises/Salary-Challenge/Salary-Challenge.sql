USE SoftUni

SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS a
WHERE Salary > 
	(
		SELECT AVG(b.Salary) FROM Employees AS b
		WHERE b.DepartmentID = a.DepartmentID
		GROUP BY b.DepartmentID
	)
ORDER BY DepartmentID