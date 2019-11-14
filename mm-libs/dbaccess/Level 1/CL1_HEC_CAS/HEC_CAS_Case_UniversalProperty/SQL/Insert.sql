INSERT INTO 
	hec_cas_case_universalproperties
	(
		HEC_CAS_Case_UniversalPropertyID,
		GlobalPropertyMatchingID,
		PropertyName,
		IsValue_String,
		IsValue_Number,
		IsValue_Boolean,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CAS_Case_UniversalPropertyID,
		@GlobalPropertyMatchingID,
		@PropertyName,
		@IsValue_String,
		@IsValue_Number,
		@IsValue_Boolean,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)