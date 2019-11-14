
	Select
	  Count(*) As OrgUnitNumber
	From
	  cmn_str_office_weekly_worktimetemplates Right Join
	  cmn_str_offices On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_weekly_worktimetemplates.Office_RefID And
	    cmn_str_office_weekly_worktimetemplates.IsDeleted = 0 And
	    cmn_str_office_weekly_worktimetemplates.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_str_office_responsiblepersons On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_responsiblepersons.Office_RefID And
	    cmn_str_office_responsiblepersons.IsDeleted = 0 And
	    cmn_str_office_responsiblepersons.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_str_office_2_officetype On cmn_str_office_2_officetype.Office_RefID =
	    cmn_str_offices.CMN_STR_OfficeID And cmn_str_office_2_officetype.IsDeleted =
	    0 And cmn_str_office_2_officetype.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_str_office_types On cmn_str_office_types.CMN_STR_Office_TypeID =
	    cmn_str_office_2_officetype.Office_Type_RefID  And
	  cmn_str_office_types.IsDeleted = 0 And
	  cmn_str_office_types.Tenant_RefID = @TenantID
	Where
	  cmn_str_office_weekly_worktimetemplates.CMN_STR_Office_Weekly_WorkTimeTemplateID Is Null And
	  cmn_str_offices.IsDeleted = 0 And
	  cmn_str_offices.Tenant_RefID = @TenantID
  