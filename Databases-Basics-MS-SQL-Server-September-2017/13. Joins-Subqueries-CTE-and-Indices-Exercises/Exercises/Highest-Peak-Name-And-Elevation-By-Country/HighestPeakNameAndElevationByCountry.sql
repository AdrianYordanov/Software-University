USE [Geography]

SELECT TOP (5)
CountryName AS [Country],
CASE
WHEN HighestPeakName IS NULL THEN '(no highest peak)'
ELSE HighestPeakName 
END AS [Highest Peak Name],

CASE
WHEN HighestPeakElevation IS NULL THEN 0	
ELSE HighestPeakElevation  
END AS [Highest Peak Elevation],

CASE
WHEN Mountain IS NULL THEN '(no mountain)'	
ELSE Mountain  
END AS Mountain
FROM
(
	SELECT
	c.CountryName, 
	p.PeakName AS [HighestPeakName],
	MAX(p.Elevation) AS [HighestPeakElevation],
	m.MountainRange AS [Mountain]
	FROM Countries AS c
	LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT OUTER JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT OUTER JOIN Peaks AS p ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName, m.MountainRange, p.PeakName
) AS HighestPeaks
ORDER BY Country, [Highest Peak Name]