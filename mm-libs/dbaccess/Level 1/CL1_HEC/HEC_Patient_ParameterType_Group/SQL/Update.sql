UPDATE 
	hec_patient_parametertype_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Name_DictID=@Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_ParameterType_GroupID = @HEC_Patient_ParameterType_GroupID