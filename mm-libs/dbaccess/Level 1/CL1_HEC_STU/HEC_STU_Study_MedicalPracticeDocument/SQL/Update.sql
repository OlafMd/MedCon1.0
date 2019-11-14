UPDATE 
	hec_stu_study_medicalpracticedocument
SET 
	ParticipatingMedicalPractice_RefID=@ParticipatingMedicalPractice_RefID,
	ParticipationRequiredDocument_RefID=@ParticipationRequiredDocument_RefID,
	Document_RefID=@Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_STU_Study_MedicalPracticeDocumentID = @HEC_STU_Study_MedicalPracticeDocumentID