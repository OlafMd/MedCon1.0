INSERT INTO 
	hec_stu_study_patientdocuments
	(
		HEC_STU_Study_PatientDocumentID,
		ParticipationRequiredDocument_RefID,
		ParticipatingPatient_RefID,
		Document_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_STU_Study_PatientDocumentID,
		@ParticipationRequiredDocument_RefID,
		@ParticipatingPatient_RefID,
		@Document_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)