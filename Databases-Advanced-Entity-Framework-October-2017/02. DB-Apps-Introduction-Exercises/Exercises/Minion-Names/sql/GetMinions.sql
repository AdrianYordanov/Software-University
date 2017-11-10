SELECT m.[Name], m.Age FROM Villains AS v
INNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
INNER JOIN Minions AS m ON m.Id = mv.MinionId
WHERE v.Id = @villainId