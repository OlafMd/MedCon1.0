UPDATE 
	acc_fiscalyears
SET 
	FiscalYearName=@FiscalYearName,
	StartDate=@StartDate,
	EndDate=@EndDate,
	IsClosed=@IsClosed,
	IsFinalized=@IsFinalized,
	IfFinalized_FollowingFiscalYear_RefID=@IfFinalized_FollowingFiscalYear_RefID,
	IsFinalizationTriggered=@IsFinalizationTriggered,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_FiscalYearID = @ACC_FiscalYearID