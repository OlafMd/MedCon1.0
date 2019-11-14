INSERT INTO 
	tms_sks_skill
	(
		TMS_SKS_SkillID,
		Name,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_SKS_SkillID,
		@Name,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)