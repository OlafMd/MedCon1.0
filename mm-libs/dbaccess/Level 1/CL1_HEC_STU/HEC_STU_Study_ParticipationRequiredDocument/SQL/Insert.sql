INSERT INTO 
	hec_stu_study_participationrequireddocuments
	(
		HEC_STU_Study_ParticipatingPatient_RequiredDocumentID,
		DOC_SLT_DocumentSlot_RefID,
		Study_RefID,
		IsRequiredFor_MedicalPractiseParticipation,
		IsRequiredFor_PatientParticipation,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_STU_Study_ParticipatingPatient_RequiredDocumentID,
		@DOC_SLT_DocumentSlot_RefID,
		@Study_RefID,
		@IsRequiredFor_MedicalPractiseParticipation,
		@IsRequiredFor_PatientParticipation,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)