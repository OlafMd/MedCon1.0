UPDATE 
	res_bld_facades
SET 
	Building_RefID=@Building_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_FacadeID = @RES_BLD_FacadeID