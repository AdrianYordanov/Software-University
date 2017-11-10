SELECT v.[Name], COUNT(*) AS [Minions Count] FROM Villains AS v
INNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
GROUP BY v.[Name]
HAVING COUNT(*) > 3
ORDER BY[Minions Count] DESC