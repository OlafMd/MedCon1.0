UPDATE 
	hec_patient_2_patienttreatment
SET 
	HEC_Patient_RefID=@HEC_Patient_RefID,
	HEC_Patient_Treatment_RefID=@HEC_Patient_Treatment_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID