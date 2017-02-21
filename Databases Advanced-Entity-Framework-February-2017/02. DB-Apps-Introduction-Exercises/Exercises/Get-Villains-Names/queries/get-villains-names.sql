USE MinionsDB

SELECT v.Name, COUNT(*) AS [MinionsCount] FROM Villains AS v
JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
GROUP BY v.Name
HAVING COUNT(*) > 3
ORDER BY [MinionsCount] DESC