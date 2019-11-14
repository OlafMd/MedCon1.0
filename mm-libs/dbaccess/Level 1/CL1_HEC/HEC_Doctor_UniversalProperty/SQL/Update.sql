UPDATE 
	hec_doctor_universalproperties
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	PropertyName=@PropertyName,
	IsValue_String=@IsValue_String,
	IsValue_Number=@IsValue_Number,
	IsValue_Boolean=@IsValue_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Doctor_UniversalPropertyID = @HEC_Doctor_UniversalPropertyID