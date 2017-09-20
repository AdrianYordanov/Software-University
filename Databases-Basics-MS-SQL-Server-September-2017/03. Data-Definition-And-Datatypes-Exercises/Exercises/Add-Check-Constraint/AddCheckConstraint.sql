USE Minions

ALTER TABLE Users
ADD CONSTRAINT CK_Pwd_Min_Five_Symbols
CHECK(LEN([Password]) >= 5)