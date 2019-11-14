INSERT INTO 
	hec_patient_documents
	(
		HEC_Patient_DocumentID,
		Patient_RefID,
		Document_RefID,
		IsDocument_Standard,
		IsDocument_PatientConsent,
		IsDocument_PatientParticipationPolicy,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_Patient_DocumentID,
		@Patient_RefID,
		@Document_RefID,
		@IsDocument_Standard,
		@IsDocument_PatientConsent,
		@IsDocument_PatientParticipationPolicy,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)