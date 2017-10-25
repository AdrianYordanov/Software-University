USE ReportService

SELECT c.[Name], COUNT(*) AS [ReportsNumber] FROM Categories AS c
INNER JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY COUNT(*) DESC, c.[Name]