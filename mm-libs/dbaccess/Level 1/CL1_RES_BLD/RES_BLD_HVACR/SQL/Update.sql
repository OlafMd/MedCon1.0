UPDATE 
	res_bld_hvacrs
SET 
	Building_RefID=@Building_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_HVACRID = @RES_BLD_HVACRID