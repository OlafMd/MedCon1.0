
Select
  cmn_str_professions.CMN_STR_ProfessionID,
  cmn_str_professions.ProfessionName_DictID,
  cmn_str_professionkeys.SocialSecurityProfessionKey,
  cmn_countries.Country_ISOCode_Alpha2,
  cmn_str_professions.GlobalPropertyMatchingID
From
  cmn_str_professions Inner Join
  cmn_str_professionkeys On cmn_str_professionkeys.CMN_STR_Profession_RefID =
    cmn_str_professions.CMN_STR_ProfessionID Inner Join
  cmn_economicregion On cmn_economicregion.CMN_EconomicRegionID =
    cmn_str_professionkeys.CMN_EconomicRegion_RefID Inner Join
  cmn_country_2_economicregion
    On cmn_country_2_economicregion.CMN_EconomicRegion_RefID =
    cmn_economicregion.CMN_EconomicRegionID Inner Join
  cmn_countries On cmn_country_2_economicregion.CMN_Country_RefID =
    cmn_countries.CMN_CountryID
Where
  cmn_str_professions.IsDeleted = 0 And
  cmn_str_professions.Tenant_RefID = @TenantID
  