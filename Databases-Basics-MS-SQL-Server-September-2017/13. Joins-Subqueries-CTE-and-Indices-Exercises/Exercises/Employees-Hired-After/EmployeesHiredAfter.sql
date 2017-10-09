USE SoftUni

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS [DeptName]
FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.Name IN ('Sales', 'Finance')