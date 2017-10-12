USE [Geography]

SELECT COUNT(*) AS [CountCountriesDontHaveMountain]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL