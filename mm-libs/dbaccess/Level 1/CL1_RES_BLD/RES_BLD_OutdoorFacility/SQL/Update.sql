UPDATE 
	res_bld_outdoorfacilities
SET 
	Building_RefID=@Building_RefID,
	NumberOfGaragePlaces=@NumberOfGaragePlaces,
	NumberOfRentedGaragePlaces=@NumberOfRentedGaragePlaces,
	TypeOfAccessRoad_RefID=@TypeOfAccessRoad_RefID,
	TypeOfFence_RefID=@TypeOfFence_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_OutdoorFacilityID = @RES_BLD_OutdoorFacilityID