UPDATE 
	hec_doctor_universalpropertyvalues
SET 
	HEC_Doctor_RefID=@HEC_Doctor_RefID,
	UniversalProperty_RefID=@UniversalProperty_RefID,
	Value_String=@Value_String,
	Value_Number=@Value_Number,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Doctor_UniversalPropertyValueID = @HEC_Doctor_UniversalPropertyValueID