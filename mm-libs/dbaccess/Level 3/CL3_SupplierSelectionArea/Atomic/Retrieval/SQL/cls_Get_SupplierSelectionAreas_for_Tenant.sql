
	Select
      log_reg_supplierselectionareas.LOG_REG_SupplierSelectionAreaID,
      log_reg_supplierselectionareas.SupplierSelectionArea_Name_DictID,
      log_reg_supplierselectionareas.SupplierSelectionArea_Description_DictID
    From
      log_reg_supplierselectionareas
    Where
      log_reg_supplierselectionareas.Tenant_RefID = @TenantID And
      log_reg_supplierselectionareas.IsDeleted = 0
  