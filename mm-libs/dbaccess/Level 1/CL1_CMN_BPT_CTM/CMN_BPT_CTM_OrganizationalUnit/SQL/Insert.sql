INSERT INTO 
	cmn_bpt_ctm_organizationalunits
	(
		CMN_BPT_CTM_OrganizationalUnitID,
		CustomerTenant_OfficeITL,
		InternalOrganizationalUnitNumber,
		InternalOrganizationalUnitSimpleName,
		ExternalOrganizationalUnitNumber,
		Customer_RefID,
		Parent_OrganizationalUnit_RefID,
		OrganizationalUnit_SimpleName,
		OrganizationalUnit_Name_DictID,
		OrganizationalUnit_Description_DictID,
		Default_PhoneNumber,
		Default_FaxNumber,
		DisplayImage_Document_RefID,
		IsMedicalPractice,
		IfMedicalPractise_HEC_MedicalPractice_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_CTM_OrganizationalUnitID,
		@CustomerTenant_OfficeITL,
		@InternalOrganizationalUnitNumber,
		@InternalOrganizationalUnitSimpleName,
		@ExternalOrganizationalUnitNumber,
		@Customer_RefID,
		@Parent_OrganizationalUnit_RefID,
		@OrganizationalUnit_SimpleName,
		@OrganizationalUnit_Name,
		@OrganizationalUnit_Description,
		@Default_PhoneNumber,
		@Default_FaxNumber,
		@DisplayImage_Document_RefID,
		@IsMedicalPractice,
		@IfMedicalPractise_HEC_MedicalPractice_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)