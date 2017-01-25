USE Movies

-- Creating tables.
CREATE TABLE Directors(
	Id int NOT NULL IDENTITY,
	DirectorName varchar(50) NOT NULL,
	Notes ntext
)
CREATE TABLE Genres(
	Id int NOT NULL IDENTITY,
	GenreName varchar(50) NOT NULL,
	Notes ntext
)
CREATE TABLE Categories(
	Id int NOT NULL IDENTITY,
	CategoryName varchar(50) NOT NULL,
	Notes ntext
)
CREATE TABLE Movies(
	Id int NOT NULL IDENTITY,
	Title varchar(30) NOT NULL,
	DirectorId int NOT NULL,
	CopyrightYear int,
	Length int NOT NULL,
	GenreId int NOT NULL,
	CategoryId int NOT NULL,
	Rating real NOT NULL,
	Notes ntext
)

-- Setting primary keys.
ALTER TABLE Directors
ADD CONSTRAINT PK_Directors PRIMARY KEY (Id)
ALTER TABLE Genres
ADD CONSTRAINT PK_Genres PRIMARY KEY (Id)
ALTER TABLE Categories
ADD CONSTRAINT PK_Categories PRIMARY KEY (Id)
ALTER TABLE Movies
ADD CONSTRAINT PK_Movies PRIMARY KEY (Id)

-- Setting checkers.
ALTER TABLE Movies
ADD CONSTRAINT CK_CopyrightYear_Movies CHECK (CopyrightYear > 0)
ALTER TABLE Movies
ADD CONSTRAINT CK_Rating_Movies CHECK(Rating BETWEEN 0.0 AND 10.0)
ALTER TABLE Movies
ADD CONSTRAINT CK_Length_Movies CHECK(Length > 0)

-- Populating tables.
INSERT INTO Directors (DirectorName, Notes)
VALUES
('Adrian', 'Adrian note'),
('Peter', NULL),
('George', 'Gosho note'),
('Stanislav', NULL),
('Ivan', 'Ivan note');
INSERT INTO Genres(GenreName, Notes)
VALUES
('Comedy', 'funny movies'),
('Action', NULL),
('Drama', 'sad movies'),
('Sitcom', NULL),
('Criminal', 'bad guys movies');
INSERT INTO Categories(CategoryName, Notes)
VALUES
('Interesting', 'interesting movies note'),
('New', NULL),
('Family', 'boring movies note'),
('College', NULL),
('Romantic', 'romantic movies note');
INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES
('Titanic', 2, 2006, 178, 3, 4, 8.5, 'One of the biggest romantic movies.'),
('Pain and Gain', 1, 2013, 128, 2, 5, 9.2, 'Movie about fitness and bad people.'),
('Good Kids', 3, 2015, 120, 1, 4, 9.1, 'Movie about young kids.'),
('The Accountant', 5, 2016, 145, 5, 4, 10, 'Really interesting movie.'),
('Malcolm in the middle', 4, 2005, 28, 4, 3, 8, 'One of the favourite moives of everybody.');