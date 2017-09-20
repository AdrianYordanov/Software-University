USE Minions

ALTER TABLE Users
ADD CONSTRAINT Default_Value_LastLoginTime
DEFAULT (GETDATE()) FOR LastLoginTime