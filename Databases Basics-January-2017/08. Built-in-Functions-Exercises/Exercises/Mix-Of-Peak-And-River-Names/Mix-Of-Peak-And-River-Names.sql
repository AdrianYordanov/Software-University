USE Geography

SELECT PeakName, RiverName, LOWER(PeakName) + LOWER(RIGHT(RiverName, LEN(RiverName) - 1)) as 'Mix'
FROM Peaks
CROSS JOIN Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix