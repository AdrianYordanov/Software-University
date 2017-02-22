USE MinionsDB

SELECT m.Name AS [MinionName], m.Age AS [MinionAge] FROM Villains AS v
JOIN MinionsVillains AS vm ON vm.VillainId = v.Id
JOIN Minions AS m ON vm.MinionId = m.Id
WHERE v.Id = @VillainId