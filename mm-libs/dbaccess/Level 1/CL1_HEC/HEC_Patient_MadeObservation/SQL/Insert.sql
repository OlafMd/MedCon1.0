INSERT INTO 
	hec_patient_madeobservations
	(
		HEC_Patient_MadeObservationID,
		Patient_Diagnosis_RefID,
		Patient_RefID,
		Observation_RefID,
		Comment,
		Creation_Timestamp,
		Modification_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_Patient_MadeObservationID,
		@Patient_Diagnosis_RefID,
		@Patient_RefID,
		@Observation_RefID,
		@Comment,
		@Creation_Timestamp,
		@Modification_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)