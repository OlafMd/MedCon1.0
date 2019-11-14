UPDATE 
	cmn_loc_location
SET 
	Region_RefID=@Region_RefID,
	Address_RefID=@Address_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_LOC_LocationID = @CMN_LOC_LocationID