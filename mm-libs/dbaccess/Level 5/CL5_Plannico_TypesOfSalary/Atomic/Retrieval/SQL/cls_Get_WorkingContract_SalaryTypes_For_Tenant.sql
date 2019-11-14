
	Select
	  cmn_bpt_emp_workingcontract_salarytypes.CMN_BPT_EMP_WorkingContract_SalaryTypeID,
	  cmn_bpt_emp_workingcontract_salarytypes.CMN_BPT_EMP_WorkingContract_RefID,
	  cmn_bpt_emp_workingcontract_salarytypes.CMN_BPT_EMP_SalaryTypeID,
	  cmn_bpt_emp_workingcontract_salarytypes.Amount
	From
	  cmn_bpt_emp_workingcontract_salarytypes
	Where
	  cmn_bpt_emp_workingcontract_salarytypes.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_workingcontract_salarytypes.IsDeleted = 0
  