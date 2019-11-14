UPDATE 
	cmn_bpt_ctm_organizationalunit_addresses
SET 
	UniversalContactDetail_Address_RefID=@UniversalContactDetail_Address_RefID,
	OrganizationalUnit_RefID=@OrganizationalUnit_RefID,
	IsPrimary=@IsPrimary,
	AddressType=@AddressType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_CTM_OrganizationalUnit_AddressID = @CMN_BPT_CTM_OrganizationalUnit_AddressID