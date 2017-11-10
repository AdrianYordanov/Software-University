CREATE TABLE Towns 
(
	Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), 
	CountryId INT NOT NULL, 
	CONSTRAINT FK_TownCountry FOREIGN KEY (CountryId) REFERENCES Countries(Id)
)                