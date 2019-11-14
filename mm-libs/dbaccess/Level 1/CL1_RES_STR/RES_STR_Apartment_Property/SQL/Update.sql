UPDATE 
	res_str_apartment_properties
SET 
	ApartmentProperty_Name_DictID=@ApartmentProperty_Name,
	ApartmentProperty_Description_DictID=@ApartmentProperty_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Apartment_PropertyID = @RES_STR_Apartment_PropertyID