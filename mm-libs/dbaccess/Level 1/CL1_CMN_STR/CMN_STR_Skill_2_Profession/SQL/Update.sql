UPDATE 
	cmn_str_skill_2_profession
SET 
	Profession_RefID=@Profession_RefID,
	Skill_RefID=@Skill_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID