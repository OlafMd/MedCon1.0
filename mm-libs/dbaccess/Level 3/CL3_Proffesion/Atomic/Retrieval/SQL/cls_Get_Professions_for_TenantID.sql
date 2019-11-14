
Select
  cmn_str_professions.ProfessionName_DictID,
  cmn_str_professions.CMN_STR_ProfessionID,
  cmn_str_professionkeys.CMN_STR_ProfessionKeyID,
  cmn_str_professionkeys.SocialSecurityProfessionKey,
  cmn_str_skills.CMN_STR_SkillID,
  cmn_str_skills.Skill_Name_DictID
From
  cmn_str_professions Left Join
  cmn_str_professionkeys On cmn_str_professions.CMN_STR_ProfessionID =
    cmn_str_professionkeys.CMN_STR_Profession_RefID And
    cmn_str_professionkeys.IsDeleted = 0 And cmn_str_professionkeys.Tenant_RefID
    = @TenantID Left Join
  cmn_str_skill_2_profession On cmn_str_professions.CMN_STR_ProfessionID =
    cmn_str_skill_2_profession.Profession_RefID And
    cmn_str_skill_2_profession.IsDeleted = 0 And
    cmn_str_skill_2_profession.Tenant_RefID = @TenantID Left Join
  cmn_str_skills On cmn_str_skill_2_profession.Skill_RefID =
    cmn_str_skills.CMN_STR_SkillID And cmn_str_skills.IsDeleted = 0 And
    cmn_str_skills.Tenant_RefID = @TenantID
Where
  cmn_str_professions.IsDeleted = 0 And
  cmn_str_professions.Tenant_RefID = @TenantID
  