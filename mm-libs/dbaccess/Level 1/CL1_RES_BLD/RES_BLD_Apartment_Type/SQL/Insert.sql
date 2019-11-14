INSERT INTO 
	res_bld_apartment_types
	(
		RES_BLD_Apartment_TypeID,
		ApartmentType_Name_DictID,
		ApartmentType_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@RES_BLD_Apartment_TypeID,
		@ApartmentType_Name,
		@ApartmentType_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)