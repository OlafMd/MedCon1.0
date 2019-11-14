UPDATE 
	res_bld_staircases
SET 
	Building_RefID=@Building_RefID,
	StaircaseSize_Unit_RefID=@StaircaseSize_Unit_RefID,
	StaircaseSize_Value=@StaircaseSize_Value,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_StaircaseID = @RES_BLD_StaircaseID