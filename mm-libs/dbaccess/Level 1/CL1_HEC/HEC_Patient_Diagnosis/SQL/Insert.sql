INSERT INTO 
	hec_patient_diagnoses
	(
		HEC_Patient_DiagnosisID,
		Patient_RefID,
		R_IsAssumed,
		R_IsNegated,
		R_IsConfirmed,
		R_IsActive,
		R_DiagnosedOnDate,
		R_ScheduledExpiryDate,
		R_DeactivatedOnDate,
		R_PotentialDiagnosis_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Patient_DiagnosisID,
		@Patient_RefID,
		@R_IsAssumed,
		@R_IsNegated,
		@R_IsConfirmed,
		@R_IsActive,
		@R_DiagnosedOnDate,
		@R_ScheduledExpiryDate,
		@R_DeactivatedOnDate,
		@R_PotentialDiagnosis_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)