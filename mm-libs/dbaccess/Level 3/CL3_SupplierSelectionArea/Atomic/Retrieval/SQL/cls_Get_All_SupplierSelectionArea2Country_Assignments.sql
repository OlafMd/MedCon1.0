
Select Distinct
  log_reg_supplierselectionarea_2_country.CMN_Country_RefID
From
  log_reg_supplierselectionarea_2_country
Where
  log_reg_supplierselectionarea_2_country.Tenant_RefID = @TenantID And
  log_reg_supplierselectionarea_2_country.IsDeleted = 0
  