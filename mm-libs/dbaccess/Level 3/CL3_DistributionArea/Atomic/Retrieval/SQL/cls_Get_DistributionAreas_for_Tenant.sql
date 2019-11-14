
	Select
	  log_reg_distributionareas.LOG_REG_DistributionAreaID,
	  log_reg_distributionareas.DistributionArea_Name_DictID
	From
	  log_reg_distributionareas
	Where
	  log_reg_distributionareas.IsDeleted = 0 And
	  log_reg_distributionareas.Tenant_RefID = @TenantID
  