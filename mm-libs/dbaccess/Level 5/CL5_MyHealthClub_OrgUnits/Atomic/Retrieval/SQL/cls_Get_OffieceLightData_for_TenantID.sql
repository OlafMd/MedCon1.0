
	Select
	  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
	  cmn_str_offices.Office_Name_DictID,
	  cmn_addresses.Country_ISOCode,
	  cmn_addresses.Street_Name,
	  cmn_addresses.Street_Number,
	  cmn_addresses.City_Name
	From
	  cmn_str_offices Left Join
	  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_addresses.Office_RefID And
	    cmn_str_office_addresses.Tenant_RefID = @TenantID And
	    cmn_str_office_addresses.IsDeleted = 0 And
	    cmn_str_office_addresses.IsDefault = 1 Left Join
	  cmn_addresses On cmn_addresses.CMN_AddressID =
	    cmn_str_office_addresses.CMN_Address_RefID And cmn_addresses.IsDeleted = 0
	    And cmn_addresses.Tenant_RefID = @TenantID
	Where
	  cmn_str_offices.Tenant_RefID = @TenantID And
	  cmn_str_offices.IsDeleted = 0
  