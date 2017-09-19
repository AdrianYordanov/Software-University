CREATE FUNCTION f_CalculateTotalBalance (@ClientID INT)
RETURNS DECIMAL(15, 2)
BEGIN
	DECLARE @result AS DECIMAL(15, 2) = (
	  SELECT SUM(Balance) 
	  FROM Accounts WHERE ClientId = @ClientID
	)	
  RETURN @result
END