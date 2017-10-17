USE Bank

GO

CREATE PROC usp_GetHoldersFullName
AS
SELECT CONCAT(FirstName, ' ', LastName) AS [FullName] 
FROM AccountHolders