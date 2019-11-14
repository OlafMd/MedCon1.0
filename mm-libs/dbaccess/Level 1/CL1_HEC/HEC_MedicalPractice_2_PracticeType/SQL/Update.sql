UPDATE 
	hec_medicalpractice_2_practicetype
SET 
	HEC_MedicalPractice_RefID=@HEC_MedicalPractice_RefID,
	HEC_MedicalPractice_Type_RefID=@HEC_MedicalPractice_Type_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	IsPrimaryType=@IsPrimaryType
WHERE 
	AssignmentID = @AssignmentID