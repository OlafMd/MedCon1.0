UPDATE 
	hec_patient_parametertype_2_parametertypegroup
SET 
	HEC_Patient_ParameterType_RefID=@HEC_Patient_ParameterType_RefID,
	HEC_Patient_ParameterType_Group_RefID=@HEC_Patient_ParameterType_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID