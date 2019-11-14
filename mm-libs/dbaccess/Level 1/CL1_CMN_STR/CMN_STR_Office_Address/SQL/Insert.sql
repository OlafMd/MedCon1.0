INSERT INTO 
	cmn_str_office_addresses
	(
		CMN_STR_Office_AddressID,
		Office_RefID,
		CMN_Address_RefID,
		IsShippingAddress,
		IsBillingAddress,
		IsSpecialAddress,
		IfSpecialAddress_Name,
		IsDefault,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_Office_AddressID,
		@Office_RefID,
		@CMN_Address_RefID,
		@IsShippingAddress,
		@IsBillingAddress,
		@IsSpecialAddress,
		@IfSpecialAddress_Name,
		@IsDefault,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)