DECLARE @evilnessId INT = (SELECT Id FROM EvilnessFactors WHERE [Name] = 'Evil' COLLATE Latin1_General_CS_AS)

INSERT INTO Villains VALUES
(@villainName, @evilnessId)