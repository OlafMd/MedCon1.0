UPDATE 
	cmn_str_pps_activity_skillassignments
SET 
	CMN_STR_Skill_RefID=@CMN_STR_Skill_RefID,
	CMN_STR_PPS_Activity_RefID=@CMN_STR_PPS_Activity_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_RequiredSkillAssignmentID = @CMN_STR_PPS_RequiredSkillAssignmentID