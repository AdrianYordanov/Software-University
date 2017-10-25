USE ReportService

SELECT 
Department,
Category,
[Percentage]
FROM
(
	SELECT 
	D.[Name] AS Department,
	C.[Name] AS Category,
	CAST(
		ROUND(COUNT(1) OVER(PARTITION BY C.Id) * 100.00 / COUNT(1) OVER(PARTITION BY D.Id), 0) AS INT
	) AS [Percentage]
	FROM Categories AS C
	JOIN Reports AS R ON R.Categoryid = C.Id
	JOIN Departments AS D ON D.Id = C.Departmentid
) AS [Stats]
GROUP BY Department, Category, [Percentage]
ORDER BY Department, Category, [Percentage]