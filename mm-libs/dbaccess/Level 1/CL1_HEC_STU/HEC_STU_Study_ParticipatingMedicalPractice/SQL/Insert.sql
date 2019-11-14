INSERT INTO 
	hec_stu_study_participatingmedicalpractices
	(
		HEC_STU_Study_ParticipatingMedicalPracticeID,
		Study_RefID,
		MedicalPractice_RefID,
		Participation_DateOfSigning,
		Participation_Comment,
		ParticipationPolicyInternalNumber,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_STU_Study_ParticipatingMedicalPracticeID,
		@Study_RefID,
		@MedicalPractice_RefID,
		@Participation_DateOfSigning,
		@Participation_Comment,
		@ParticipationPolicyInternalNumber,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)