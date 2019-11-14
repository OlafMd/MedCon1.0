UPDATE 
	hec_stu_study_patientdocuments
SET 
	ParticipationRequiredDocument_RefID=@ParticipationRequiredDocument_RefID,
	ParticipatingPatient_RefID=@ParticipatingPatient_RefID,
	Document_RefID=@Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_STU_Study_PatientDocumentID = @HEC_STU_Study_PatientDocumentID