USE MinionsDB

CREATE TABLE Towns (
	Id int PRIMARY KEY IDENTITY,
    Name varchar(50),
	CountryName varchar(50)
)

CREATE TABLE Minions (
    Id int PRIMARY KEY IDENTITY,
	Name varchar(50),
    Age int,
    TownId int,
    CONSTRAINT FK_Minions_Town_Countries_Id
	FOREIGN KEY (TownId) REFERENCES Towns(Id)
)

CREATE TABLE Villains (
    Id int PRIMARY KEY IDENTITY,
    Name varchar(50),
	EvilnessFactor varchar(10),
    CONSTRAINT CK_Villains_EvilnessFactor
    CHECK (EvilnessFactor IN('good', 'bad', 'evil', 'super evil'))
)

CREATE TABLE MinionsVillains (
    MinionId int,
    VillainId int,
    CONSTRAINT PK_MinionId_VillainId
    PRIMARY KEY (MinionId, VillainId)
)

INSERT INTO Towns VALUES
('Sofia', 'Bulgaria'),
('Plovdiv', 'Bulgaria'),
('Rome', 'Italy'),
('Gabrovo', 'Bulgaria'),
('France', 'Paris')

INSERT INTO Minions VALUES
('Ivan', 15, 1),
('Tihomir', 20, 4),
('Stanislav', 18, 1),
('Peter', 42, 3),
('Adrian', 19, 4)

INSERT INTO Villains VALUES
('Monika', 'bad'),
('Luboslav', 'good'),
('Tsvetoslav', 'super evil'),
('Gabriel', 'evil'),
('Ivailo', 'good')

INSERT INTO MinionsVillains VALUES
(1, 5),
(3, 2),
(4, 5),
(2, 3),
(5, 1)