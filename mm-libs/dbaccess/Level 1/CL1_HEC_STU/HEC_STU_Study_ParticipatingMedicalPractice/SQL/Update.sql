UPDATE 
	hec_stu_study_participatingmedicalpractices
SET 
	Study_RefID=@Study_RefID,
	MedicalPractice_RefID=@MedicalPractice_RefID,
	Participation_DateOfSigning=@Participation_DateOfSigning,
	Participation_Comment=@Participation_Comment,
	ParticipationPolicyInternalNumber=@ParticipationPolicyInternalNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_STU_Study_ParticipatingMedicalPracticeID = @HEC_STU_Study_ParticipatingMedicalPracticeID