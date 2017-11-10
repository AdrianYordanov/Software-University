CREATE TABLE MinionsVillains
(
	MinionId INT,
	VillainId INT, CONSTRAINT FK_Minions FOREIGN KEY (MinionId) REFERENCES Minions(Id),
	CONSTRAINT  FK_Villains FOREIGN KEY (VillainId) REFERENCES Villains(Id),
	CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId)
)       