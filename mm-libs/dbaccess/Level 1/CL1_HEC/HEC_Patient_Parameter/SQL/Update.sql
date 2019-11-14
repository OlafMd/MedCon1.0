UPDATE 
	hec_patient_parameters
SET 
	PatientParameterITL=@PatientParameterITL,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Parameter_Name_DictID=@Parameter_Name,
	IsFloat=@IsFloat,
	IfFloat_MinValue=@IfFloat_MinValue,
	IfFloat_MaxValue=@IfFloat_MaxValue,
	IsFloat_ApplicableUnit_RefID=@IsFloat_ApplicableUnit_RefID,
	IsString=@IsString,
	IsVitalParameter=@IsVitalParameter,
	HasHighRelevance=@HasHighRelevance,
	ParameterType_RefID=@ParameterType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_ParameterID = @HEC_Patient_ParameterID