USE ReportService

CREATE TRIGGER T_CloseReport ON Reports AFTER UPDATE
AS
BEGIN
	UPDATE Reports
	SET StatusId = (SELECT Id FROM Status WHERE Label = 'completed')
	WHERE Id IN
	(
		SELECT Id FROM inserted
		WHERE Id IN 
		(
			SELECT Id FROM deleted
			WHERE CloseDate IS NULL
		)
		AND CloseDate IS NOT NULL
	)   
END;