USE [Geography]

SELECT c.CountryCode, COUNT(*) AS [MountainRanges]
FROM Countries AS c
INNER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
INNER JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode