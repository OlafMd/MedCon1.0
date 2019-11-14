UPDATE 
	hec_patient_documents
SET 
	Patient_RefID=@Patient_RefID,
	Document_RefID=@Document_RefID,
	IsDocument_Standard=@IsDocument_Standard,
	IsDocument_PatientConsent=@IsDocument_PatientConsent,
	IsDocument_PatientParticipationPolicy=@IsDocument_PatientParticipationPolicy,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_DocumentID = @HEC_Patient_DocumentID