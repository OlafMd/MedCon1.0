UPDATE 
	res_bld_hvacr_2_hvacr_type
SET 
	RES_BLD_HVACR_RefID=@RES_BLD_HVACR_RefID,
	RES_BLD_HVACR_Type_RefID=@RES_BLD_HVACR_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID