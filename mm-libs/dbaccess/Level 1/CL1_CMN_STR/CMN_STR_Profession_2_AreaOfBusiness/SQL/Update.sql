UPDATE 
	cmn_str_profession_2_areaofbusiness
SET 
	AreaOfBusiness_RefID=@AreaOfBusiness_RefID,
	Profession_RefID=@Profession_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID