UPDATE 
	cmn_bpt_emp_workingcontract_2_contractemploymenttypes
SET 
	CMN_BPT_EMP_Employee_WorkingContract_RefID=@CMN_BPT_EMP_Employee_WorkingContract_RefID,
	CMN_BPT_EMP_WorkingContract_EmploymentTypeID=@CMN_BPT_EMP_WorkingContract_EmploymentTypeID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID