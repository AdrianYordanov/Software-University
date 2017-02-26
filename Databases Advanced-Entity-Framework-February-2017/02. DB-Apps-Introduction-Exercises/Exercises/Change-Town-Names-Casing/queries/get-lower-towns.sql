USE MinionsDB

SELECT Name FROM Towns
WHERE (CountryName = @SelectedCountry) AND (Name COLLATE Latin1_General_CS_AI <> UPPER(Name))