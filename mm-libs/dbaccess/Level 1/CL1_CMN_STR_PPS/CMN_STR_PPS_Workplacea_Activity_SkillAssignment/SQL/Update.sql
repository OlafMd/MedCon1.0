UPDATE 
	cmn_str_pps_workplacea_activity_skillassignments
SET 
	CMN_STR_Skill_RefID=@CMN_STR_Skill_RefID,
	Workplace_Activity_RefID=@Workplace_Activity_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_PPS_Workplace_RequiredSkillAssignmentID = @CMN_STR_PPS_Workplace_RequiredSkillAssignmentID