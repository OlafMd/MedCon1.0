
Select
  cmn_countries.CMN_CountryID,
  cmn_countries.Default_Language_RefID,
  cmn_countries.Default_Currency_RefID,
  cmn_countries.Country_Name_DictID,
  cmn_countries.Country_ISOCode_Alpha2,
  cmn_countries.Country_ISOCode_Alpha3,
  cmn_countries.Country_ISOCode_Numeric,
  cmn_countries.Tenant_RefID
From
  cmn_countries
Where
  cmn_countries.IsDeleted = 0
  