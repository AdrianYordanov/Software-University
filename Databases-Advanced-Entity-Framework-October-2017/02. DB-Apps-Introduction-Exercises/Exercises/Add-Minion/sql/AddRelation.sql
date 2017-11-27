DECLARE @villainId INT = (SELECT Id FROM Villains WHERE [Name] = @villainName COLLATE Latin1_General_CS_AS)
DECLARE @minionId INT = (SELECT Id FROM Minions WHERE [Name] = @minionName COLLATE Latin1_General_CS_AS)

INSERT INTO MinionsVillains VALUES
(@minionId, @villainId)