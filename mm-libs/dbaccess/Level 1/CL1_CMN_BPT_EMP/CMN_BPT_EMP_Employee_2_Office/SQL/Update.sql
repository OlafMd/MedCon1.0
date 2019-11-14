UPDATE 
	cmn_bpt_emp_employee_2_office
SET 
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID