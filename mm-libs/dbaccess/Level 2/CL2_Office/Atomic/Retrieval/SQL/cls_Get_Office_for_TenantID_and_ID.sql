
		Select
		  cmn_str_offices.CMN_STR_OfficeID,
       cmn_str_offices.Default_BillingAddress_RefID,
		  cmn_str_offices.Parent_RefID,
		  cmn_str_offices.Office_Name_DictID,
		  cmn_str_offices.Office_Description_DictID,
	    cmn_str_offices.Office_InternalName,
      cmn_str_offices.Office_InternalNumber
		From
		  cmn_str_offices
		Where
		  cmn_str_offices.Tenant_RefID = @TenantID And cmn_str_offices.CMN_STR_OfficeID = @OfficeID
		  AND cmn_str_offices.IsDeleted = 0
  