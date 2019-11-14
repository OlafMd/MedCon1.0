UPDATE 
	cmn_str_office_addresses
SET 
	Office_RefID=@Office_RefID,
	CMN_Address_RefID=@CMN_Address_RefID,
	IsShippingAddress=@IsShippingAddress,
	IsBillingAddress=@IsBillingAddress,
	IsSpecialAddress=@IsSpecialAddress,
	IfSpecialAddress_Name=@IfSpecialAddress_Name,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_AddressID = @CMN_STR_Office_AddressID