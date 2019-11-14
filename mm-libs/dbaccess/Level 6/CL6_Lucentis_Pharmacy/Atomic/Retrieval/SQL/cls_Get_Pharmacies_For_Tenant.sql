
	Select
	  cmn_bpt_businessparticipants.DisplayName,
	  hec_pharmacies.HEC_PharmacyID
	From
	  cmn_com_companyinfo Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
	  hec_pharmacies On hec_pharmacies.Ext_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID
	Where
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  cmn_com_companyinfo.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsCompany = 1 And
	  cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = 0 And
	  cmn_bpt_businessparticipants.IsTenant = 0 And
	  hec_pharmacies.IsDeleted = 0 And
	  hec_pharmacies.Tenant_RefID = @TenantID
  