USE SoftUni

SELECT DepartmentID, Salary AS [ThirdHighestSalary] FROM
(
	SELECT 
	DepartmentID, 
	Salary, 
	RANK() OVER (PARTITION BY DepartmentID ORDER BY SALARY DESC) AS [Rank] 
	FROM Employees
	GROUP BY DepartmentID, Salary
) AS RankingTable
WHERE [Rank] = 3