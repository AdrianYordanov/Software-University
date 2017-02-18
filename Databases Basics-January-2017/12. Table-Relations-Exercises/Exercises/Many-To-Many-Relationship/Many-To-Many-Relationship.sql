USE Test

CREATE TABLE Students(
	StudentID int PRIMARY KEY IDENTITY,
	Name varchar(50),
)

CREATE TABLE Exams(
	ExamID int PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50),
)

CREATE TABLE StudentsExams(
	StudentID int FOREIGN KEY references Students(StudentID),
	ExamID int FOREIGN KEY references Exams(ExamID),
	CONSTRAINT PK_StudentID_ExamID
	PRIMARY KEY(StudentId, ExamID)
)

INSERT INTO Students
VALUES 
('Mila'),
('Toni'), 
('Roni')

INSERT INTO Exams
VALUES 
('SpringMVC'),
('Neo4j'),
('Oracle 11g')


INSERT INTO StudentsExams
VALUES 
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)