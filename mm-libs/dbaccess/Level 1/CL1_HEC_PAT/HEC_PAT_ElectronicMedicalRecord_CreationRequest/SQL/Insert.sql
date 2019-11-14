INSERT INTO 
	hec_pat_electronicmedicalrecord_creationrequests
	(
		HEC_PAT_ElectronicMedicalRecord_CreationRequestID,
		Patient_RefID,
		RequestedBy_BusinessParticipant_RefID,
		RequestDate,
		IsEMRFileCreated,
		EMRFile_ExternalURL,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_PAT_ElectronicMedicalRecord_CreationRequestID,
		@Patient_RefID,
		@RequestedBy_BusinessParticipant_RefID,
		@RequestDate,
		@IsEMRFileCreated,
		@EMRFile_ExternalURL,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)