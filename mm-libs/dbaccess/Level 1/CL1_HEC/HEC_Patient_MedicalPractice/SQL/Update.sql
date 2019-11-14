UPDATE 
	hec_patient_medicalpractices
SET 
	HEC_Patient_RefID=@HEC_Patient_RefID,
	HEC_MedicalPractices_RefID=@HEC_MedicalPractices_RefID,
	IsMainPractise=@IsMainPractise,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_MedicalPracticeID = @HEC_Patient_MedicalPracticeID