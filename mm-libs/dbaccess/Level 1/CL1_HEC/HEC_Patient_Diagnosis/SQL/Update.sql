UPDATE 
	hec_patient_diagnoses
SET 
	Patient_RefID=@Patient_RefID,
	R_IsAssumed=@R_IsAssumed,
	R_IsNegated=@R_IsNegated,
	R_IsConfirmed=@R_IsConfirmed,
	R_IsActive=@R_IsActive,
	R_DiagnosedOnDate=@R_DiagnosedOnDate,
	R_ScheduledExpiryDate=@R_ScheduledExpiryDate,
	R_DeactivatedOnDate=@R_DeactivatedOnDate,
	R_PotentialDiagnosis_RefID=@R_PotentialDiagnosis_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_DiagnosisID = @HEC_Patient_DiagnosisID