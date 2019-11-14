INSERT INTO 
	hec_patient_medicalpractices
	(
		HEC_Patient_MedicalPracticeID,
		HEC_Patient_RefID,
		HEC_MedicalPractices_RefID,
		IsMainPractise,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_Patient_MedicalPracticeID,
		@HEC_Patient_RefID,
		@HEC_MedicalPractices_RefID,
		@IsMainPractise,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)