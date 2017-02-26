USE MinionsDB

UPDATE Towns
SET Name = UPPER(Name)
WHERE CountryName = @SelectedCountry