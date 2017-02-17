USE SoftUni

SELECT * INTO newTableEmployees
FROM Employees
WHERE Salary > 30000

DELETE FROM newTableEmployees
WHERE ManagerID = 42

UPDATE newTableEmployees
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] FROM newTableEmployees
GROUP BY DepartmentID

DROP TABLE newTableEmployees