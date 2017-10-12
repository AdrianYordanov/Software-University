USE [Geography]

SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM
(
	SELECT 
	ContinentCode, 
	CurrencyCode,
	CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY (ContinentCode) ORDER BY CurrencyUsage DESC) [Rank]
	FROM
	(
		SELECT ContinentCode, CurrencyCode, COUNT(*) AS [CurrencyUsage]
		FROM Countries
		GROUP BY CurrencyCode, ContinentCode
	) AS currencies
) AS rankedTable
WHERE [Rank] = 1 AND CurrencyUsage != 1
ORDER BY ContinentCode