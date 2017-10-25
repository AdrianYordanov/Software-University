USE ReportService

SELECT 
E.Firstname + ' ' + E.Lastname AS FullName, 
ISNULL(CONVERT(varchar, CC.ReportSum), '0') + '/' + ISNULL(CONVERT(varchar, OC.ReportSum), '0') AS [Stats]
FROM Employees AS e
JOIN 
(
	SELECT EmployeeId,  COUNT(1) AS ReportSum
	FROM Reports r
	WHERE  YEAR(OpenDate) = 2016
	GROUP BY EmployeeId
) AS oc ON oc.Employeeid = e.Id
LEFT JOIN 
(
	SELECT EmployeeId,  COUNT(1) AS ReportSum
	FROM Reports r
	WHERE  YEAR(CloseDate) = 2016
	GROUP BY EmployeeId
) AS cc ON cc.Employeeid = e.Id
ORDER BY FullName