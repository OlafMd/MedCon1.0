UPDATE 
	hec_patient_parametertypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Name_DictID=@Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_ParameterTypeID = @HEC_Patient_ParameterTypeID