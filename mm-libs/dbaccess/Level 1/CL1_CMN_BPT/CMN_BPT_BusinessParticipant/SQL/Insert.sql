INSERT INTO 
	cmn_bpt_businessparticipants
	(
		CMN_BPT_BusinessParticipantID,
		BusinessParticipantITL,
		ImportedFromSource,
		DisplayName,
		IsNaturalPerson,
		IsCompany,
		IfNaturalPerson_CMN_PER_PersonInfo_RefID,
		IfCompany_CMN_COM_CompanyInfo_RefID,
		IsTenant,
		IfTenant_Tenant_RefID,
		DisplayImage_RefID,
		DefaultLanguage_RefID,
		DefaultCurrency_RefID,
		LastContacted_Date,
		LastContacted_ByBusinessPartner_RefID,
		Audit_UpdatedByAccount_RefID,
		Audit_CreatedByAccount_RefID,
		Audit_UpdatedOn,
		IsDeleted,
		Tenant_RefID,
		Creation_Timestamp,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_BusinessParticipantID,
		@BusinessParticipantITL,
		@ImportedFromSource,
		@DisplayName,
		@IsNaturalPerson,
		@IsCompany,
		@IfNaturalPerson_CMN_PER_PersonInfo_RefID,
		@IfCompany_CMN_COM_CompanyInfo_RefID,
		@IsTenant,
		@IfTenant_Tenant_RefID,
		@DisplayImage_RefID,
		@DefaultLanguage_RefID,
		@DefaultCurrency_RefID,
		@LastContacted_Date,
		@LastContacted_ByBusinessPartner_RefID,
		@Audit_UpdatedByAccount_RefID,
		@Audit_CreatedByAccount_RefID,
		@Audit_UpdatedOn,
		@IsDeleted,
		@Tenant_RefID,
		@Creation_Timestamp,
		@Modification_Timestamp
	)