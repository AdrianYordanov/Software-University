USE ReportService

SELECT 
D.[Name] AS Departmentname,
ISNULL(CONVERT(VARCHAR, AVG(DATEDIFF(DAY, R.Opendate, R.Closedate))), 'no info') AS AverageTime
FROM Departments AS d
JOIN Categories AS c ON C.DepartmentId = d.Id
LEFT JOIN Reports AS r ON R.CategoryId = c.Id
GROUP BY d.[Name]
ORDER BY d.[Name]