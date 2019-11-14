UPDATE 
	hec_patients
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	HasSignedParticipationPolicyDocument=@HasSignedParticipationPolicyDocument,
	PatientComment=@PatientComment,
	IsPatientParticipationPolicyValidated=@IsPatientParticipationPolicyValidated,
	PatientParticipationPolicyValidatedBy_Account_RefID=@PatientParticipationPolicyValidatedBy_Account_RefID,
	EmployerCompanyName=@EmployerCompanyName,
	PatientProfession=@PatientProfession,
	IsTenant=@IsTenant,
	Current_EMRFile_ExternalURL=@Current_EMRFile_ExternalURL,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_PatientID = @HEC_PatientID