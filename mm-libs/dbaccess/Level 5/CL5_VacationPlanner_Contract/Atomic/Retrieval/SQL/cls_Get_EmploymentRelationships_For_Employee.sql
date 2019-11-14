
	Select
	  cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID,
	  cmn_bpt_emp_employmentrelationships.HasWorkRelationEnded,
	  cmn_bpt_emp_employmentrelationships.Work_StartDate,
	  cmn_bpt_emp_employmentrelationships.Work_EndDate
	From
	  cmn_bpt_emp_employmentrelationships
	Where
	  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationships.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_employmentrelationships.Employee_RefID = @EmployeeID
  