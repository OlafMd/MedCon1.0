INSERT INTO 
	hec_patient_2_patienttreatment
	(
		AssignmentID,
		HEC_Patient_RefID,
		HEC_Patient_Treatment_RefID,
		Creation_Timestamp,
		Modification_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@HEC_Patient_RefID,
		@HEC_Patient_Treatment_RefID,
		@Creation_Timestamp,
		@Modification_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)