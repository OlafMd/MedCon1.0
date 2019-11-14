UPDATE 
	cmn_bpt_publicoffice_addresses
SET 
	CMN_BPT_PublicOffice_RefID=@CMN_BPT_PublicOffice_RefID,
	CMN_UniversalContactDetails_RefID=@CMN_UniversalContactDetails_RefID,
	IsDefault=@IsDefault,
	IsContactAddress=@IsContactAddress,
	IsShippingAddress=@IsShippingAddress,
	IsBillingAddress=@IsBillingAddress,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_PublicOffice_AddressID = @CMN_BPT_PublicOffice_AddressID