UPDATE 
	rel_bld_facades
SET 
	Building_RefID=@Building_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	REL_BLD_FacadeID = @REL_BLD_FacadeID