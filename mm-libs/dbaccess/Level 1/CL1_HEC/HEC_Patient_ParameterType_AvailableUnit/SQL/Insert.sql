INSERT INTO 
	hec_patient_parametertype_availableunits
	(
		HEC_Patient_ParameterType_AvailableUnitID,
		Patient_ParameterType_RefID,
		Unit_RefID,
		IsDefaultUnit,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Patient_ParameterType_AvailableUnitID,
		@Patient_ParameterType_RefID,
		@Unit_RefID,
		@IsDefaultUnit,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)