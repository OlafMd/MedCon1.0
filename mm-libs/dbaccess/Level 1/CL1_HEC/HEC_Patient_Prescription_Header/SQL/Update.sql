UPDATE 
	hec_patient_prescription_headers
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	Patient_RefID=@Patient_RefID,
	PrescribedBy_Doctor_RefID=@PrescribedBy_Doctor_RefID,
	Prescription_InternalNumber=@Prescription_InternalNumber,
	Prescription_Date=@Prescription_Date,
	Prescription_Comment=@Prescription_Comment,
	Perscription_UploadedByBusinessParticipant_RefID=@Perscription_UploadedByBusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_Prescription_HeaderID = @HEC_Patient_Prescription_HeaderID