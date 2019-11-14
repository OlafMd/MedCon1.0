UPDATE 
	tms_developertask_2_sks_skill
SET 
	DeveloperTask_RefID=@DeveloperTask_RefID,
	Skill_RefID=@Skill_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID