
Select
  cmn_economicregion.CMN_EconomicRegionID,
  cmn_economicregion.ParentEconomicRegion_RefID,
  cmn_economicregion.EconomicRegion_Name_DictID,
  cmn_economicregion.EconomicRegion_Description_DictID,
  cmn_economicregion.IsEconomicRegionCountry,
  cmn_country_2_economicregion.AssignmentID,
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID,
  cmn_countries.Country_ISOCode_Alpha2,
  cmn_countries.IsActive,
  cmn_countries.IsDefault
From
  cmn_economicregion Left Join
  cmn_country_2_economicregion On cmn_economicregion.CMN_EconomicRegionID =
    cmn_country_2_economicregion.CMN_EconomicRegion_RefID And
    cmn_country_2_economicregion.IsDeleted = 0 And
    cmn_country_2_economicregion.Tenant_RefID = @TenantID Left Join
  cmn_countries On cmn_country_2_economicregion.CMN_Country_RefID =
    cmn_countries.CMN_CountryID And cmn_countries.IsDeleted = 0 And
    cmn_countries.Tenant_RefID = @TenantID
Where
  cmn_economicregion.IsDeleted = 0 And
  cmn_economicregion.Tenant_RefID = @TenantID
  