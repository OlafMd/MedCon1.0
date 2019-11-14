UPDATE 
	cmn_bpt_ctm_organizationalunits
SET 
	CustomerTenant_OfficeITL=@CustomerTenant_OfficeITL,
	InternalOrganizationalUnitNumber=@InternalOrganizationalUnitNumber,
	InternalOrganizationalUnitSimpleName=@InternalOrganizationalUnitSimpleName,
	ExternalOrganizationalUnitNumber=@ExternalOrganizationalUnitNumber,
	Customer_RefID=@Customer_RefID,
	Parent_OrganizationalUnit_RefID=@Parent_OrganizationalUnit_RefID,
	OrganizationalUnit_SimpleName=@OrganizationalUnit_SimpleName,
	OrganizationalUnit_Name_DictID=@OrganizationalUnit_Name,
	OrganizationalUnit_Description_DictID=@OrganizationalUnit_Description,
	Default_PhoneNumber=@Default_PhoneNumber,
	Default_FaxNumber=@Default_FaxNumber,
	DisplayImage_Document_RefID=@DisplayImage_Document_RefID,
	IsMedicalPractice=@IsMedicalPractice,
	IfMedicalPractise_HEC_MedicalPractice_RefID=@IfMedicalPractise_HEC_MedicalPractice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_CTM_OrganizationalUnitID = @CMN_BPT_CTM_OrganizationalUnitID