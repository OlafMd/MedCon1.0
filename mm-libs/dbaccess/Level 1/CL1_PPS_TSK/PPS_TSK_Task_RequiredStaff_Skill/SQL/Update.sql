UPDATE 
	pps_tsk_task_requiredstaff_skills
SET 
	RequiredStaff_RefID=@RequiredStaff_RefID,
	CMN_STR_Skill_RefID=@CMN_STR_Skill_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_RequiredStaff_SkillID = @PPS_TSK_Task_RequiredStaff_SkillID