USE SoftUni

SELECT 
e.EmployeeID, 
e.FirstName,
CASE
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.Name	
END AS [ProjectName]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24