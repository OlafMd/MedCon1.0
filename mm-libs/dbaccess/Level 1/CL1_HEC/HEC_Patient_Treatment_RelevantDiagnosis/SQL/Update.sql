UPDATE 
	hec_patient_treatment_relevantdiagnoses
SET 
	Patient_Treatment_RefID=@Patient_Treatment_RefID,
	Doctor_RefID=@Doctor_RefID,
	DIA_PotentialDiagnosis_RefID=@DIA_PotentialDiagnosis_RefID,
	DIA_State_RefID=@DIA_State_RefID,
	RelevantDiagnosis_Comment=@RelevantDiagnosis_Comment,
	DiagnosedOnDate=@DiagnosedOnDate,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Treatment_RelevantDiagnosisID = @HEC_Patient_Treatment_RelevantDiagnosisID