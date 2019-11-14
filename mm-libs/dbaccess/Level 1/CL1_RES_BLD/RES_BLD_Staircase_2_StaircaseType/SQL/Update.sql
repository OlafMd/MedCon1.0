UPDATE 
	res_bld_staircase_2_staircasetype
SET 
	RES_BLD_Staircase_RefID=@RES_BLD_Staircase_RefID,
	RES_BLD_Staircase_Type_RefID=@RES_BLD_Staircase_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID