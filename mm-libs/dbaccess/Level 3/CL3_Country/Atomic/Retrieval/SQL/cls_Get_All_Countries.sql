
Select
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID,
  cmn_countries.Country_ISOCode_Alpha3,
  cmn_countries.Country_ISOCode_Alpha2
From
  cmn_countries
Where
  cmn_countries.IsDeleted = 0 and cmn_countries.Tenant_RefID=cast(0x00000000000000000000000000000000 as binary)
  