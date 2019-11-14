
Select Distinct
  cmn_countries.Country_ISOCode_Alpha2
From
  cmn_countries Inner Join
  cmn_countries_de On cmn_countries.Country_Name_DictID =
    cmn_countries_de.DictID
Where
  cmn_countries_de.Content Like @CountryName And
  cmn_countries.IsDeleted = 0
  