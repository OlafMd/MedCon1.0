
	Select
	  hec_medicalpractises.HEC_MedicalPractiseID,
	  cmn_bpt_businessparticipants.DisplayName,
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber
	From
	  hec_medicalpractises Inner Join
	  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID
	Where
	  hec_medicalpractises.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  cmn_com_companyinfo.IsDeleted = 0 And
	  hec_medicalpractises.Tenant_RefID = @TenantID And
	  cmn_bpt_businessparticipants.IsCompany = 1 And
	  cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = 0 And
	  cmn_bpt_businessparticipants.IsTenant = 1
  