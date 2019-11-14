INSERT INTO 
	hec_doctor_universalpropertyvalues
	(
		HEC_Doctor_UniversalPropertyValueID,
		HEC_Doctor_RefID,
		UniversalProperty_RefID,
		Value_String,
		Value_Number,
		Value_Boolean,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Doctor_UniversalPropertyValueID,
		@HEC_Doctor_RefID,
		@UniversalProperty_RefID,
		@Value_String,
		@Value_Number,
		@Value_Boolean,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)