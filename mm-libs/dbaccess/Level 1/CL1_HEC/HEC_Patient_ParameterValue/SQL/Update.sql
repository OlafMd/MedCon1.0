UPDATE 
	hec_patient_parametervalues
SET 
	Patient_RefID=@Patient_RefID,
	PatientParameter_RefID=@PatientParameter_RefID,
	DateOfValue=@DateOfValue,
	IsConfirmed=@IsConfirmed,
	ConfirmedBy_Doctor_RefID=@ConfirmedBy_Doctor_RefID,
	EnteredBy_Doctor_RefID=@EnteredBy_Doctor_RefID,
	DateOfEntry=@DateOfEntry,
	StringValue=@StringValue,
	FloatValue=@FloatValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_ParameterValueID = @HEC_Patient_ParameterValueID