UPDATE 
	hec_patient_diagnosis_2_patientmedication
SET 
	HEC_Patient_Diagnosis_RefID=@HEC_Patient_Diagnosis_RefID,
	HEC_Patient_Medication_RefID=@HEC_Patient_Medication_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID