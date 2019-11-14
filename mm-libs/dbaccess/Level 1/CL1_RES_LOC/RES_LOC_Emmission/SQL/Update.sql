UPDATE 
	res_loc_emmissions
SET 
	Emmission_Name_DictID=@Emmission_Name,
	Emmission_Description_DictID=@Emmission_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_EmmissionID = @RES_LOC_EmmissionID