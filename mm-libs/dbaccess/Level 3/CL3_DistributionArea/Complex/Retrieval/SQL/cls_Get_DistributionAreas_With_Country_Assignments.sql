
Select
  log_reg_distributionareas.LOG_REG_DistributionAreaID,
  log_reg_distributionareas.DistributionArea_Name_DictID,
  log_reg_distributionareas.DistributionArea_Description_DictID,
  log_reg_distributionarea_2_country.AssignmentID,
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID,
  cmn_countries.Country_ISOCode_Alpha2,
  cmn_countries.IsActive,
  cmn_countries.IsDefault
From
  log_reg_distributionareas Left Join
  log_reg_distributionarea_2_country
    On log_reg_distributionareas.LOG_REG_DistributionAreaID =
    log_reg_distributionarea_2_country.LOG_REG_DistributionArea_RefID And
    log_reg_distributionarea_2_country.IsDeleted = 0 And
    log_reg_distributionarea_2_country.Tenant_RefID = @TenantID Left Join
  cmn_countries On log_reg_distributionarea_2_country.CMN_Country_RefID =
    cmn_countries.CMN_CountryID And cmn_countries.IsDeleted = 0 And
    cmn_countries.Tenant_RefID = @TenantID
Where
  log_reg_distributionareas.IsDeleted = 0 And
  log_reg_distributionareas.Tenant_RefID = @TenantID
  