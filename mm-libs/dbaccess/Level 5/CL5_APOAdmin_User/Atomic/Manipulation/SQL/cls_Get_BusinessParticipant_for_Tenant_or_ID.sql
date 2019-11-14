
	Select
		cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	  cmn_bpt_businessparticipants.Tenant_RefID,
	  cmn_bpt_businessparticipants.DisplayName,
	  cmn_bpt_businessparticipants.IsNaturalPerson,
	  cmn_bpt_businessparticipants.IsCompany,
	  cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
	  cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
	  cmn_bpt_businessparticipants.DisplayImage_RefID,
	  cmn_bpt_businessparticipants.DefaultLanguage_RefID,
	  cmn_bpt_businessparticipants.DefaultCurrency_RefID,
	  cmn_bpt_businessparticipants.LastContacted_Date,
	  cmn_bpt_businessparticipants.LastContacted_ByBusinessPartner_RefID,
	  cmn_bpt_businessparticipants.Audit_UpdatedByAccount_RefID,
	  cmn_bpt_businessparticipants.Audit_UpdatedOn,
	  cmn_bpt_businessparticipants.Audit_CreatedByAccount_RefID
		From
		  cmn_bpt_businessparticipants
		Where
		  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = IfNull(@ID, cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID) And
		  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
		  cmn_bpt_businessparticipants.IsDeleted = 0

  