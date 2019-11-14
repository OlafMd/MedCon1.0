UPDATE 
	res_bld_basements
SET 
	Building_RefID=@Building_RefID,
	TypeOfFloor_RefID=@TypeOfFloor_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_BasementID = @RES_BLD_BasementID