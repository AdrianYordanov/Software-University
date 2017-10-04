USE SoftUni

SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING NOT MAX(Salary) BETWEEN 30000 AND 70000