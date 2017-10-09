USE SoftUni

SELECT TOP 3 e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN
(
	SELECT EmployeeID FROM EmployeesProjects
	GROUP BY EmployeeID
) AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID