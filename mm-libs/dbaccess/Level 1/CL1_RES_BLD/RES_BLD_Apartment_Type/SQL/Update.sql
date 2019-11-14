UPDATE 
	res_bld_apartment_types
SET 
	ApartmentType_Name_DictID=@ApartmentType_Name,
	ApartmentType_Description_DictID=@ApartmentType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Apartment_TypeID = @RES_BLD_Apartment_TypeID