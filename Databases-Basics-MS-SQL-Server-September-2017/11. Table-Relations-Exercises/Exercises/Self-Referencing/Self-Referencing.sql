USE ExampleDatabase

CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	ManagerID INT
)

INSERT INTO Teachers([Name], ManagerID) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT FK_Teachers_ManagerID_TeacherID
FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)