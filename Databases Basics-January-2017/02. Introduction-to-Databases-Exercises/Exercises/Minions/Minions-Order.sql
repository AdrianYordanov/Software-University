/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Name]
  FROM [Minions].[dbo].[Minions]
  ORDER BY [Name] ASC