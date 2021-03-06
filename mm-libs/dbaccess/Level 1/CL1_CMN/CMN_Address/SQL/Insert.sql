INSERT INTO 
	cmn_addresses
	(
		CMN_AddressID,
		Street_Name,
		Street_Number,
		City_AdministrativeDistrict,
		City_Region,
		City_Name,
		City_PostalCode,
		Province_Name,
		Country_Name,
		CareOf,
		Country_ISOCode,
		Province_EconomicRegion_RefID,
		Lattitude,
		Longitude,
		POBox,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_AddressID,
		@Street_Name,
		@Street_Number,
		@City_AdministrativeDistrict,
		@City_Region,
		@City_Name,
		@City_PostalCode,
		@Province_Name,
		@Country_Name,
		@CareOf,
		@Country_ISOCode,
		@Province_EconomicRegion_RefID,
		@Lattitude,
		@Longitude,
		@POBox,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)