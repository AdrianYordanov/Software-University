USE SoftUni

SELECT TownID, [Name] FROM Towns
WHERE NOT (LEFT([Name], 1) IN ('R', 'B', 'D'))
ORDER BY [Name]