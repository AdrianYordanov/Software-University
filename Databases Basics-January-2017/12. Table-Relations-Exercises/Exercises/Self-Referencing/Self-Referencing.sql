USE Test

CREATE TABLE Teachers(
	TeacherID int NOT NULL PRIMARY KEY IDENTITY(101, 1),
	Name varchar(50) NOT NULL,
	ManagerID int FOREIGN KEY references Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)