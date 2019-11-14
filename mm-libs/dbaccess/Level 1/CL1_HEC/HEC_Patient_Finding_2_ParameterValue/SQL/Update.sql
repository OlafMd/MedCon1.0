UPDATE 
	hec_patient_finding_2_parametervalues
SET 
	HEC_Patient_Finding_RefID=@HEC_Patient_Finding_RefID,
	HEC_Patient_ParameterValue_RefID=@HEC_Patient_ParameterValue_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID