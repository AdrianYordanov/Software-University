USE Test

CREATE TABLE Majors(
	MajorID int PRIMARY KEY,
	Name varchar(50)
)

CREATE TABLE Students(
	StudentID int PRIMARY KEY,
	StudentNumber varchar(20),
	StudentName varchar(50),
	MajorID int FOREIGN KEY references Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID int PRIMARY KEY,
	PaymentDate date,
	PaymentAmount money,
	StudentID int FOREIGN KEY references Students(StudentID)
)

CREATE TABLE Subjects(
	SubjectID int PRIMARY KEY,
	SubjectName varchar(50)
)

CREATE TABLE Agenda(
	StudentID int FOREIGN KEY references Students(StudentID),
	SubjectID int FOREIGN KEY references Subjects(SubjectID)
	CONSTRAINT PK_StudentID_SubjectID
	PRIMARY KEY(StudentID, SubjectID)
)