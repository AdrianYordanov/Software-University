USE Bank

GO

CREATE PROC usp_GetHoldersWithBalanceHigherThan @checkMoney MONEY
AS
SELECT ah.FirstName, ah.LastName FROM AccountHolders AS ah
INNER JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @checkMoney