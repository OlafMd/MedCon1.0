UPDATE 
	hec_patient_universalproperties
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	PropertyName=@PropertyName,
	IsValue_String=@IsValue_String,
	IfValue_String_DefaultValue=@IfValue_String_DefaultValue,
	IsValue_Number=@IsValue_Number,
	IfValue_Number_DefaultValue=@IfValue_Number_DefaultValue,
	IsValue_Boolean=@IsValue_Boolean,
	IfValue_Boolean_DefaultValue=@IfValue_Boolean_DefaultValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_UniversalPropertyID = @HEC_Patient_UniversalPropertyID