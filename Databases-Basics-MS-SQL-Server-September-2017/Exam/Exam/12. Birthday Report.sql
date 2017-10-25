USE ReportService

SELECT c.[Name] FROM Categories AS c
INNER JOIN Reports AS r ON r.CategoryId = c.Id
INNER JOIN Users AS u ON u.Id = r.UserId
WHERE DATEPART(DAY, u.BirthDate) = DATEPART(DAY, r.OpenDate) AND
DATEPART(MONTH, u.BirthDate) = DATEPART(MONTH, r.OpenDate) 
GROUP BY c.[Name]
ORDER BY c.[Name]