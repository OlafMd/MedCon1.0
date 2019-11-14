UPDATE 
	tms_accountprofile_2_sks_skill
SET 
	AccountProfile_RefID=@AccountProfile_RefID,
	Skill_RefID=@Skill_RefID,
	Rating=@Rating,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID