UPDATE 
	hec_patient_treatment_ocularextension
SET 
	HEC_Patient_Treatment_RefID=@HEC_Patient_Treatment_RefID,
	IsTreatmentOfLeftEye=@IsTreatmentOfLeftEye,
	IsTreatmentOfRightEye=@IsTreatmentOfRightEye,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Treatment_OcularExtensionID = @HEC_Patient_Treatment_OcularExtensionID