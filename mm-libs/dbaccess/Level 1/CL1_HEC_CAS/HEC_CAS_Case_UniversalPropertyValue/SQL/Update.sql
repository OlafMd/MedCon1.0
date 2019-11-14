UPDATE 
	hec_cas_case_universalpropertyvalue
SET 
	HEC_CAS_Case_RefID=@HEC_CAS_Case_RefID,
	HEC_CAS_Case_UniversalProperty_RefID=@HEC_CAS_Case_UniversalProperty_RefID,
	Value_String=@Value_String,
	Value_Number=@Value_Number,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_UniversalPropertyValueID = @HEC_CAS_Case_UniversalPropertyValueID