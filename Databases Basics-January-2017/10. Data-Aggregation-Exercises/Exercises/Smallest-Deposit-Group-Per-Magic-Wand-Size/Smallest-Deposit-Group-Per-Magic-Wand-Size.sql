USE Gringotts

SELECT a.DepositGroup FROM WizzardDeposits AS a
GROUP BY a.DepositGroup
HAVING AVG(a.MagicWandSize) =
	(
		SELECT MIN(avg_magicWandSize) FROM
		(
			SELECT AVG(b.MagicWandSize) AS [avg_magicWandSize] FROM WizzardDeposits AS b
			GROUP BY b.DepositGroup
		)
		AS c
	)