UPDATE 
	res_bld_basement_2_basementtype
SET 
	RES_BLD_Basement_RefID=@RES_BLD_Basement_RefID,
	RES_BLD_Basement_Type_RefID=@RES_BLD_Basement_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID