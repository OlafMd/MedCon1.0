UPDATE 
	cmn_bpt_emp_workingcontract_employmenttypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	EmploymentType_Name_DictID=@EmploymentType_Name,
	EmploymentType_Description_DictID=@EmploymentType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID = @CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID