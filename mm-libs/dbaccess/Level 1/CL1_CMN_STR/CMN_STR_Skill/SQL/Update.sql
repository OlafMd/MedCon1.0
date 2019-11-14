UPDATE 
	cmn_str_skills
SET 
	Skill_Name_DictID=@Skill_Name,
	Skill_Description_DictID=@Skill_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_SkillID = @CMN_STR_SkillID