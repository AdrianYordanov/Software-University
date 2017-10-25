CREATE PROC usp_AssignEmployeeToReport (@employeeId INT, @reportId INT)
AS
BEGIN
	DECLARE @employeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	DECLARE	@reportCategoryDepartment INT =
	(
		SELECT c.DepartmentId FROM Reports AS r
		INNER JOIN Categories AS c ON c.Id = r.CategoryId
		WHERE r.Id = @reportId
	)

	BEGIN TRANSACTION
	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId

	IF (@employeeDepartment != @reportCategoryDepartment)
	BEGIN
		ROLLBACK
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 2)
	END
	COMMIT
END