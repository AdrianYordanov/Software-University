USE Diablo

SELECT 
	Name AS 'Game', 
	'Part of the Day' = CASE 
		WHEN DATEPART(hh, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(hh, Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(hh, Start) BETWEEN 18 AND 23 THEN 'Evening'
	END, 
	'Duration as String' = CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END
	FROM Games
ORDER BY Game, 'Duration as String', Start