
	Select
	  cmn_str_skills.CMN_STR_SkillID,
	  cmn_str_skills.Skill_Name_DictID,
	  cmn_str_skills.Skill_Description_DictID
	From
	  cmn_str_skills
	Where
	  cmn_str_skills.IsDeleted = 0 And
	  cmn_str_skills.Tenant_RefID = @TenantID
  