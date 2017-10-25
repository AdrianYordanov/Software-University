CREATE FUNCTION udf_GetReportsCount (@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	SET @result = 
	(
		SELECT COUNT(*) FROM Reports
		WHERE EmployeeId = @employeeId AND StatusId = @statusId
	)

	RETURN @result
END