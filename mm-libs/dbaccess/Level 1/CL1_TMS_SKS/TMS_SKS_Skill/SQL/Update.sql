UPDATE 
	tms_sks_skill
SET 
	Name=@Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_SKS_SkillID = @TMS_SKS_SkillID