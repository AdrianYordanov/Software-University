USE ReportService

SELECT 
CONCAT(e.FirstName, ' ', e.LastName) AS [Name], 
CASE
	WHEN MAX(r.UserId) IS NULL THEN 0
	ELSE COUNT(r.UserId)
END AS [Users Number]
FROM Employees AS e
LEFT OUTER JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC, [Name]