UPDATE 
	imo_res_realestates
SET 
	RealEstate_Type_RefID=@RealEstate_Type_RefID,
	Address_RefID=@Address_RefID,
	Owning_BP_RefID=@Owning_BP_RefID,
	location_lattitude=@location_lattitude,
	location_longitude=@location_longitude,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_RealEstateID = @IMO_RealEstateID