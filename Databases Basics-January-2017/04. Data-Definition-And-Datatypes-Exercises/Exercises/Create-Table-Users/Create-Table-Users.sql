USE People

CREATE TABLE Users(
	Id bigint NOT NULL IDENTITY,
	Username varchar(30) NOT NULL UNIQUE,
	Password varchar(26) NOT NULL,
	ProfilePicture varbinary(max),
	LastLoginTime date,
	IsDeleted bit
)

ALTER TABLE Users 
ADD CONSTRAINT PK_Users PRIMARY KEY(Id)
ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture_Users CHECK(DATALENGTH(ProfilePicture) < 900 * 1024)

DECLARE @C varchar(max) = '|'
-- If we set bigger or equal length than 900 * 1024, it will throw an error.
DECLARE @ProfilePicture VARBINARY(max) = Convert(VARBINARY(max), REPLICATE(@C, 900 * 1024 - 1))

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Adrian', '1234fsdgfe', @ProfilePicture, '2017-01-13', 1),
('Petur', 'dfbgdb345', @ProfilePicture, '2017-01-13', 1),
('Ivan', '234vjs234', @ProfilePicture, '2017-01-13', 0),
('George', 'Dt23G34af', @ProfilePicture, '2017-01-13', 1),
('Stanislav', '459234Fda3', @ProfilePicture, '2017-01-13', 1)