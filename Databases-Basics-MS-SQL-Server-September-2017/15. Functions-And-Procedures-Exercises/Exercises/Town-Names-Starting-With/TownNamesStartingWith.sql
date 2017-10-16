USE SoftUni

GO

CREATE PROC usp_GetTownsStartingWith @checkStartName VARCHAR(50)
AS
SELECT [Name] FROM Towns
WHERE LEFT([Name], LEN(@checkStartName)) = @checkStartName