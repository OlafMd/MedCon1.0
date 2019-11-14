UPDATE 
	res_bld_staircase_types
SET 
	StaircaseType_Name_DictID=@StaircaseType_Name,
	StaircaseType_Description_DictID=@StaircaseType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_BLD_Staircase_TypeID = @RES_BLD_Staircase_TypeID