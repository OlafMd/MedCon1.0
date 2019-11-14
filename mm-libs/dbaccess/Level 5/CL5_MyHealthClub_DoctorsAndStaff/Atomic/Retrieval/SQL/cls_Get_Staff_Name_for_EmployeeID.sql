
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName
	From
	  cmn_bpt_emp_employees Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
	    cmn_bpt_businessparticipants.IsCompany = 0 And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And cmn_per_personinfo.Tenant_RefID = @TenantID
	Where
	  cmn_bpt_emp_employees.IsDeleted = 0 And
	  cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID = @EmployeeID
  