UPDATE 
	cmn_bpt_emp_workingcontract_validityperiod
SET 
	WorkingContract_RefID=@WorkingContract_RefID,
	ValidityPeriod_StartDate=@ValidityPeriod_StartDate,
	ValidityPeriod_EndDate=@ValidityPeriod_EndDate,
	ValidityPeriod_Duration_days=@ValidityPeriod_Duration_days,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_WorkingContract_ValidityPeriodID = @CMN_BPT_EMP_WorkingContract_ValidityPeriodID