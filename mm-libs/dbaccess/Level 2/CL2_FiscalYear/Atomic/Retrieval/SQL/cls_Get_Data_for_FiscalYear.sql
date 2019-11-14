
	Select
  acc_fiscalyears.ACC_FiscalYearID,
  acc_fiscalyears.FiscalYearName,
  acc_fiscalyears.StartDate,
  acc_fiscalyears.EndDate,
  acc_fiscalyears.Creation_Timestamp,
  acc_fiscalyears.Tenant_RefID,
  acc_fiscalyears.IsClosed,
  acc_fiscalyears.IsFinalizationTriggered
From
  acc_fiscalyears
Where
  acc_fiscalyears.Tenant_RefID = @TenantID And
  acc_fiscalyears.IsDeleted = 0
  