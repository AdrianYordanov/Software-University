DECLARE @townId INT = (SELECT Id FROM Towns WHERE [Name] = @townName COLLATE Latin1_General_CS_AS)

INSERT INTO Minions VALUES
(@minionName, @minionAge, @townId)