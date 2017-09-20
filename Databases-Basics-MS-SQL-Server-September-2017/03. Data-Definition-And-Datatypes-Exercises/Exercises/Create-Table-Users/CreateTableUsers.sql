USE Minions

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime SMALLDATETIME,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Adrian', '12wqr2341', NULL, NULL, 0),
('Peter', 'sgfsg234', NULL, NULL, 0),
('George', 'wqr23rg23fs', NULL, NULL, 0),
('Ivan', 'sddgwe2dfwfq', NULL, NULL, 0),
('Stamat', '123fsdf3213', NULL, NULL, 0)