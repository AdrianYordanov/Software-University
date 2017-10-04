USE SoftUni

SELECT *
INTO EmployeesCopy
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesCopy
WHERE ManagerID = 42

UPDATE EmployeesCopy
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] 
FROM EmployeesCopy
GROUP BY DepartmentID