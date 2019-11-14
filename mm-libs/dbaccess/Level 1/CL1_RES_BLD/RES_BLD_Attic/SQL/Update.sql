UPDATE 
	res_bld_attics
SET 
	Building_RefID=@Building_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_AtticID = @RES_BLD_AtticID