UPDATE 
	cmn_bpt_emp_salarytype_2_economicregion
SET 
	CMN_BPT_EMP_SalaryType_RefID=@CMN_BPT_EMP_SalaryType_RefID,
	CMN_EconomicRegion_RefID=@CMN_EconomicRegion_RefID,
	SalaryType_Code=@SalaryType_Code,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID