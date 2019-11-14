
Select Distinct
  log_reg_distributionarea_2_country.CMN_Country_RefID
From
  log_reg_distributionarea_2_country
Where
  log_reg_distributionarea_2_country.IsDeleted = 0 And
  log_reg_distributionarea_2_country.Tenant_RefID = @TenantID
  