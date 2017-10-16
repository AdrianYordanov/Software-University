USE SoftUni

GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 0
	WHILE (@i < LEN(@word))
	BEGIN
		DECLARE @substring VARCHAR(50)
		SET @substring = LEFT(RIGHT(@word, LEN(@word) - @i), 1)
		IF (CHARINDEX(@substring, @setOfLetters) < 1)
		BEGIN
			RETURN 0
		END
		SET @i += 1
	END
	RETURN 1
END