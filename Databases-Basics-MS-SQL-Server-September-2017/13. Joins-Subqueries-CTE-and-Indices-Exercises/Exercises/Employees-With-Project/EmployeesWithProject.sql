USE SoftUni

SELECT TOP (5) e.EmployeeID, e.FirstName, P.Name AS [ProjectName]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID