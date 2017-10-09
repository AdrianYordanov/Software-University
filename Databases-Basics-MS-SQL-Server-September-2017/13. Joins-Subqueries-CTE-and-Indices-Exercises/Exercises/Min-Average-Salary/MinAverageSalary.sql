USE SoftUni

SELECT MIN([Average]) AS [MinAverageSalary] FROM
(
	SELECT (AVG(e.Salary)) AS [Average]
	FROM Employees AS e
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	GROUP BY d.DepartmentID
) AS [AverageDepartmentSalaries]