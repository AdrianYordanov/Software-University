USE People
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLeastFiveSymbols_Users
CHECK (LEN(Password) >= 5)