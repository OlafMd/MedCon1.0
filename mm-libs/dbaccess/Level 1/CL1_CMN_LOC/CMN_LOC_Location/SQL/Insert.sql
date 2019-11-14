INSERT INTO 
	cmn_loc_location
	(
		CMN_LOC_LocationID,
		Region_RefID,
		Address_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_LOC_LocationID,
		@Region_RefID,
		@Address_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)