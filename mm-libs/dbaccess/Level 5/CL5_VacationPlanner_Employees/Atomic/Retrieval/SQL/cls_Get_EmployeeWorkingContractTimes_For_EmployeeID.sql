
	Select
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.ContractAllowedAbsence_per_Month ,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID
	From
	  cmn_bpt_emp_employees Inner Join
	  cmn_bpt_emp_employmentrelationships
	    On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
	    cmn_bpt_emp_employmentrelationships.Employee_RefID Inner Join
	  cmn_bpt_emp_employmentrelationship_2_workingcontract
	    On cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
	    =
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.EmploymentRelationship_RefID Inner Join
	  cmn_bpt_emp_workingcontracts
	    On
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID =
	    cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID Inner Join
	  cmn_bpt_emp_workingcontract_allowedabsencereasons
	    On cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID =
	    cmn_bpt_emp_workingcontract_allowedabsencereasons.WorkingContract_RefID
	Where
	  cmn_bpt_emp_employees.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsDeleted = 0 And
	  cmn_bpt_emp_workingcontracts.IsDeleted = 0 And
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsDeleted = 0 And
	  cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID = @EmployeeID And
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.STA_AbsenceReason_RefID =
	  @AbsenceReasonID
  