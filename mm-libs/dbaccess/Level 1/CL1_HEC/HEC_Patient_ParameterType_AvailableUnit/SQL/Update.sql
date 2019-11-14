UPDATE 
	hec_patient_parametertype_availableunits
SET 
	Patient_ParameterType_RefID=@Patient_ParameterType_RefID,
	Unit_RefID=@Unit_RefID,
	IsDefaultUnit=@IsDefaultUnit,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_ParameterType_AvailableUnitID = @HEC_Patient_ParameterType_AvailableUnitID