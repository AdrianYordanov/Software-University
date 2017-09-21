USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] DECIMAL(5, 2) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(2, 1),
	Notes NTEXT,
)

INSERT INTO Directors (DirectorName, Notes)
VALUES
('Adrian', 'Adirans Note'),
('Peter', 'Peters Note'),
('George', 'George Note'),
('Ivan', NULL),
('Samat', 'Stamats Note')

INSERT INTO Genres (GenreName, Notes)
VALUES
('Thriller', 'Makes you scary'),
('Comedy', 'Makes you laugh'),
('Musical', 'The movie is depending on songs'),
('Romance', 'Love story movies'),
('War', 'May be movie about history')

INSERT INTO Categories(CategoryName,  Notes)
VALUES
('Category1', 'Note for Category1'),
('Category2', 'Note for Category2'),
('Category3', NULL),
('Category4', NULL),
('Category5', 'Note for Category5')


INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
('It', 1, 2017, 130.20, 1, 1, 4.2, 'Penywise which eat kids.'),
('It', 2, 1997, 120, 1, 2, 9.9, NULL),
('American Pie', 3, 1999, 130.20, 2, 3, 7.5, NULL),
('Warth of the titans', 4, 2017, 100, 5, 4, 3.5, 'Movie about the titans (the first gods).'),
('Titanic', 5, 1999, 130, 3, 5, 6.5, 'Movie about impossible love.')