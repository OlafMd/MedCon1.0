INSERT INTO 
	hec_patient_universalproperties
	(
		HEC_Patient_UniversalPropertyID,
		GlobalPropertyMatchingID,
		PropertyName,
		IsValue_String,
		IfValue_String_DefaultValue,
		IsValue_Number,
		IfValue_Number_DefaultValue,
		IsValue_Boolean,
		IfValue_Boolean_DefaultValue,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Patient_UniversalPropertyID,
		@GlobalPropertyMatchingID,
		@PropertyName,
		@IsValue_String,
		@IfValue_String_DefaultValue,
		@IsValue_Number,
		@IfValue_Number_DefaultValue,
		@IsValue_Boolean,
		@IfValue_Boolean_DefaultValue,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)