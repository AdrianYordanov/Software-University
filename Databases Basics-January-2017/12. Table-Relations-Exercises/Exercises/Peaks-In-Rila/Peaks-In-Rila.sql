USE Geography

SELECT a.MountainRange, b.PeakName, b.Elevation FROM Mountains AS a
JOIN Peaks AS b ON
a.Id = b.MountainId
WHERE a.MountainRange = 'Rila'
ORDER BY b.Elevation DESC