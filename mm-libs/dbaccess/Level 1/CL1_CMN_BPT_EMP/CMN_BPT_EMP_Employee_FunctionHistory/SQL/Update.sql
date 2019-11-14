UPDATE 
	cmn_bpt_emp_employee_functionhistory
SET 
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	CMN_BPT_EMP_WorkingContract_RefID=@CMN_BPT_EMP_WorkingContract_RefID,
	ValidThrough=@ValidThrough,
	ValidFrom=@ValidFrom,
	FunctionName=@FunctionName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_Employee_FunctionHistoryID = @CMN_BPT_EMP_Employee_FunctionHistoryID