UPDATE 
	hec_patient_universalpropertyvalues
SET 
	HEC_Patient_RefID=@HEC_Patient_RefID,
	HEC_Patient_UniversalProperty_RefID=@HEC_Patient_UniversalProperty_RefID,
	Value_String=@Value_String,
	Value_Number=@Value_Number,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_UniversalPropertyValueID = @HEC_Patient_UniversalPropertyValueID