UPDATE 
	hec_pat_electronicmedicalrecord_creationrequests
SET 
	Patient_RefID=@Patient_RefID,
	RequestedBy_BusinessParticipant_RefID=@RequestedBy_BusinessParticipant_RefID,
	RequestDate=@RequestDate,
	IsEMRFileCreated=@IsEMRFileCreated,
	EMRFile_ExternalURL=@EMRFile_ExternalURL,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_PAT_ElectronicMedicalRecord_CreationRequestID = @HEC_PAT_ElectronicMedicalRecord_CreationRequestID