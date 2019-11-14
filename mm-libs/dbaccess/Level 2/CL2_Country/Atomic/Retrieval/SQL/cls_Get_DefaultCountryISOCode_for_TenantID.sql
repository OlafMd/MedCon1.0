
	Select
	  cmn_universalcontactdetails.Country_639_1_ISOCode
	From
	  cmn_universalcontactdetails Inner Join
	  cmn_tenants On cmn_tenants.UniversalContactDetail_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID
	Where
	  cmn_tenants.CMN_TenantID = @TenantID And
	  cmn_tenants.IsDeleted = 0 And
	  cmn_universalcontactdetails.IsDeleted = 0
  