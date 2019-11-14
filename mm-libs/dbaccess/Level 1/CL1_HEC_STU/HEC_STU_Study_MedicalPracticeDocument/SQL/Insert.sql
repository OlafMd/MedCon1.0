INSERT INTO 
	hec_stu_study_medicalpracticedocument
	(
		HEC_STU_Study_MedicalPracticeDocumentID,
		ParticipatingMedicalPractice_RefID,
		ParticipationRequiredDocument_RefID,
		Document_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_STU_Study_MedicalPracticeDocumentID,
		@ParticipatingMedicalPractice_RefID,
		@ParticipationRequiredDocument_RefID,
		@Document_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)