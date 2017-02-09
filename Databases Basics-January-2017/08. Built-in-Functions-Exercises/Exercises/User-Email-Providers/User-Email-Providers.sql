USE Diablo

SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - 2) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], Username