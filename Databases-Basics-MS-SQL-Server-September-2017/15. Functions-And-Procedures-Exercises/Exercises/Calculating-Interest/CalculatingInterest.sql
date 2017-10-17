USE Bank

GO

CREATE PROC usp_CalculateFutureValueForAccount @accountId INT, @interestRate FLOAT
AS
SELECT 
ah.Id AS [AccountId],
ah.FirstName, 
ah.LastName,
a.Balance AS [CurrentBalance],
dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
INNER JOIN Accounts AS a ON a.AccountHolderId = ah.Id
WHERE a.Id = @accountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1