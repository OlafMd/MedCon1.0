
Select
  log_reg_supplierselectionareas.LOG_REG_SupplierSelectionAreaID,
  log_reg_supplierselectionareas.SupplierSelectionArea_Name_DictID,
  log_reg_supplierselectionareas.SupplierSelectionArea_Description_DictID,
  log_reg_supplierselectionarea_2_country.AssignmentID,
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID,
  cmn_countries.Country_ISOCode_Alpha2,
  cmn_countries.IsActive,
  cmn_countries.IsDefault
From
  log_reg_supplierselectionareas Left Join
  log_reg_supplierselectionarea_2_country
    On log_reg_supplierselectionareas.LOG_REG_SupplierSelectionAreaID =
    log_reg_supplierselectionarea_2_country.LOG_REG_SupplierSelectionArea_RefID
    And log_reg_supplierselectionarea_2_country.Tenant_RefID = @TenantID And
    log_reg_supplierselectionarea_2_country.IsDeleted = 0 Left Join
  cmn_countries On log_reg_supplierselectionarea_2_country.CMN_Country_RefID =
    cmn_countries.CMN_CountryID And cmn_countries.IsDeleted = 0 And
    cmn_countries.Tenant_RefID = @TenantID
Where
  log_reg_supplierselectionareas.IsDeleted = 0 And
  log_reg_supplierselectionareas.Tenant_RefID = @TenantID
  