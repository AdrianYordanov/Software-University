USE Bank

GO

CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY = @sum * POWER(1 + @yearlyInterestRate, @numberOfYears)
	RETURN @result
END