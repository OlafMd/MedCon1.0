UPDATE 
	res_str_apartment_property_availableactions
SET 
	RES_STR_Apartment_Property_RefID=@RES_STR_Apartment_Property_RefID,
	RES_ACT_Action_RefID=@RES_ACT_Action_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Apartment_Property_AvailableActionID = @RES_STR_Apartment_Property_AvailableActionID