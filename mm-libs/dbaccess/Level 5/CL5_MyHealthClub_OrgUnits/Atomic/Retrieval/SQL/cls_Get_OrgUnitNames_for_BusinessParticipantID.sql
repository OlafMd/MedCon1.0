
	Select
	  cmn_str_offices.Office_Name_DictID,
	  cmn_str_offices.CMN_STR_OfficeID
	From
	  cmn_str_offices Inner Join
	  cmn_bpt_emp_employee_2_office
	    On cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID =
	    cmn_str_offices.CMN_STR_OfficeID And
	    cmn_bpt_emp_employee_2_office.Tenant_RefID = @TenantID And
	    cmn_bpt_emp_employee_2_office.IsDeleted = 0 Inner Join
	  cmn_bpt_emp_employees On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
	    cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID And
	    cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
	    cmn_bpt_emp_employees.IsDeleted = 0 Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0
	Where
	  cmn_str_offices.IsDeleted = 0 And
	  cmn_str_offices.Tenant_RefID = @TenantID And
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
	  @BusinessParticipantID
  