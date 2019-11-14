UPDATE 
	res_bld_roof_2_rooftype
SET 
	RES_BLD_Roof_RefID=@RES_BLD_Roof_RefID,
	RES_BLD_Roof_Type_RefID=@RES_BLD_Roof_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID