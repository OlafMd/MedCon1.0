UPDATE 
	cmn_bpt_emp_workingcontract_salarytypes
SET 
	CMN_BPT_EMP_WorkingContract_RefID=@CMN_BPT_EMP_WorkingContract_RefID,
	CMN_BPT_EMP_SalaryTypeID=@CMN_BPT_EMP_SalaryTypeID,
	Amount=@Amount,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_WorkingContract_SalaryTypeID = @CMN_BPT_EMP_WorkingContract_SalaryTypeID