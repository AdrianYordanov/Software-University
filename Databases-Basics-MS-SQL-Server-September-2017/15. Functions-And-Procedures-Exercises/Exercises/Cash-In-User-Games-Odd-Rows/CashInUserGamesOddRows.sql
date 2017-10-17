USE Diablo

GO

CREATE OR ALTER FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS @cashTable TABLE
(
	SumCash MONEY	
)
AS
BEGIN
	INSERT INTO @cashTable (SumCash)
	(
		SELECT SUM(Cash) AS [SumCash] FROM
		(
			SELECT Cash FROM
			(
				SELECT 
					ug.Cash, 
					ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [RowNumber] 
				FROM Games AS g
				INNER JOIN UsersGames AS ug ON ug.GameId = g.Id
				WHERE g.Name = @gameName
			) AS userCash
			WHERE RowNumber % 2 = 1
		) AS oddCashTable
	)

	RETURN
END