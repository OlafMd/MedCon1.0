UPDATE 
	cmn_bpt_emp_employee_payroledocuments
SET 
	Employee_RefID=@Employee_RefID,
	Document_RefID=@Document_RefID,
	IsViewedByEmployee=@IsViewedByEmployee,
	DocumentDate=@DocumentDate,
	ViewedOnDate=@ViewedOnDate,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_Employee_PayroleDocumentsID = @CMN_BPT_EMP_Employee_PayroleDocumentsID