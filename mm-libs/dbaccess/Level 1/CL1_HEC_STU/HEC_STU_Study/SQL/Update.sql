UPDATE 
	hec_stu_studies
SET 
	Study_Name_DictID=@Study_Name,
	Study_Decription_DictID=@Study_Decription,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_STU_StudyID = @HEC_STU_StudyID