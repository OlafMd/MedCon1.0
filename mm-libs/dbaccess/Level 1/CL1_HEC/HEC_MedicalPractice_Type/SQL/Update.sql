UPDATE 
	hec_medicalpractice_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	MedicalPracticeType_Name_DictID=@MedicalPracticeType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_MedicalPractice_TypeID = @HEC_MedicalPractice_TypeID