
	Select
	  cmn_str_office_types.OfficeType_Name_DictID,
	  cmn_str_office_types.CMN_STR_Office_TypeID
	From
	  cmn_str_office_types
	Where
	  cmn_str_office_types.IsDeleted = 0 And
	  cmn_str_office_types.Tenant_RefID = @TenantID
  