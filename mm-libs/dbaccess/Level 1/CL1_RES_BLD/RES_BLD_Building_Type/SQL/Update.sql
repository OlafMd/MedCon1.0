UPDATE 
	res_bld_building_types
SET 
	BuildingType_Name_DictID=@BuildingType_Name,
	BuildingType_Description_DictID=@BuildingType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Building_TypeID = @RES_BLD_Building_TypeID