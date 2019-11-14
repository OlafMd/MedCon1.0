
	Select
	  cmn_str_professions.CMN_STR_ProfessionID,
	  cmn_str_skills.CMN_STR_SkillID
	From
	  cmn_str_professions Inner Join
	  cmn_str_skill_2_profession On cmn_str_professions.CMN_STR_ProfessionID =
	    cmn_str_skill_2_profession.Profession_RefID And
	    (cmn_str_skill_2_profession.IsDeleted = 0 Or
	      cmn_str_skill_2_profession.IsDeleted Is Null) Inner Join
	  cmn_str_skills On cmn_str_skills.CMN_STR_SkillID =
	    cmn_str_skill_2_profession.Skill_RefID And (cmn_str_skills.IsDeleted = 0 Or
	      cmn_str_skills.IsDeleted Is Null)
	Where
	  cmn_str_professions.IsDeleted = 0 And
	  cmn_str_professions.Tenant_RefID = @TenantID
  