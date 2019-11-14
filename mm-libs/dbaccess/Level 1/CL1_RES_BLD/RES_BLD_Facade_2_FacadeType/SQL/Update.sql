UPDATE 
	res_bld_facade_2_facadetype
SET 
	RES_BLD_Facade_RefID=@RES_BLD_Facade_RefID,
	RES_BLD_Facade_Type_RefID=@RES_BLD_Facade_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID