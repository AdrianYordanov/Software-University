USE Test

SELECT 
	Name,
	DATEDIFF(year, Birthdate, GETDATE()) AS 'Age in Years',
	DATEDIFF(month, Birthdate, GETDATE()) AS 'Age in Month',
	DATEDIFF(day, Birthdate, GETDATE()) AS 'Age in Day',
	DATEDIFF(minute, Birthdate, GETDATE()) AS 'Age in Minutes'
FROM People