UPDATE 
	hec_medicalpractice_2_universalproperty
SET 
	HEC_MedicalPractice_RefID=@HEC_MedicalPractice_RefID,
	HEC_MedicalPractice_UniversalProperty_RefID=@HEC_MedicalPractice_UniversalProperty_RefID,
	Value_String=@Value_String,
	Value_Number=@Value_Number,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID