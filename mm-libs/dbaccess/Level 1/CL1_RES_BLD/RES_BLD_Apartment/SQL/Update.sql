UPDATE 
	res_bld_apartments
SET 
	Building_RefID=@Building_RefID,
	IsAppartment_ForRent=@IsAppartment_ForRent,
	ApartmentSize_Unit_RefID=@ApartmentSize_Unit_RefID,
	ApartmentSize_Value=@ApartmentSize_Value,
	TypeOfHeating_RefID=@TypeOfHeating_RefID,
	TypeOfFlooring_RefID=@TypeOfFlooring_RefID,
	TypeOfWallCovering_RefID=@TypeOfWallCovering_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_ApartmentID = @RES_BLD_ApartmentID