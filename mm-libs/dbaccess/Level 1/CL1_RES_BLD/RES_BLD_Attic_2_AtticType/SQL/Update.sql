UPDATE 
	res_bld_attic_2_attictype
SET 
	RES_BLD_Attic_RefID=@RES_BLD_Attic_RefID,
	RES_BLD_Attic_Type_RefID=@RES_BLD_Attic_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID