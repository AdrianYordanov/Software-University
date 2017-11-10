CREATE TABLE Villains
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50), EvilnessFactorId INT,
	CONSTRAINT FK_VillainEvilnessFactor FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id)
)            