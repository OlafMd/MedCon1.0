UPDATE 
	cmn_bpt_emp_salarytypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	SalaryType_Code=@SalaryType_Code,
	SalaryType_Name_DictID=@SalaryType_Name,
	SalaryTypeStatus=@SalaryTypeStatus,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_SalaryTypeID = @CMN_BPT_EMP_SalaryTypeID