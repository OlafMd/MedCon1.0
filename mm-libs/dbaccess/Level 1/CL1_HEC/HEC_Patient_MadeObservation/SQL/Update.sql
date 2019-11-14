UPDATE 
	hec_patient_madeobservations
SET 
	Patient_Diagnosis_RefID=@Patient_Diagnosis_RefID,
	Patient_RefID=@Patient_RefID,
	Observation_RefID=@Observation_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_Patient_MadeObservationID = @HEC_Patient_MadeObservationID