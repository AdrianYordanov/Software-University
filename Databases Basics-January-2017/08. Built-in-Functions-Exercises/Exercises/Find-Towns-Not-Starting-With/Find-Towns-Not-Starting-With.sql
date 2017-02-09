USE SoftUni

SELECT * FROM Towns
WHERE (LEFT(Name, 1) != 'R') AND (LEFT(Name, 1) != 'B') AND (LEFT(Name, 1) != 'D')
ORDER BY Name