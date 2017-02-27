USE MinionsDB
GO

CREATE PROCEDURE usp_GetOlder @MinionId int
AS
UPDATE Minions
SET Age += 1
WHERE Id = @MinionId;
GO