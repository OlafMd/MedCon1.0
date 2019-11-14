
	Select
  hec_patient_parametervalues.HEC_Patient_ParameterValueID,
  hec_patient_parametervalues.Patient_RefID,
  hec_patient_parametervalues.PatientParameter_RefID,
  hec_patient_parametervalues.IsConfirmed,
  hec_patient_parametervalues.DateOfValue,
  hec_patient_parametervalues.ConfirmedBy_Doctor_RefID,
  hec_patient_parametervalues.EnteredBy_Doctor_RefID,
  hec_patient_parametervalues.DateOfEntry,
  hec_patient_parametervalues.StringValue,
  hec_patient_parametervalues.FloatValue,
  hec_patient_parametervalues.Creation_Timestamp,
  hec_patient_parametervalues.Tenant_RefID,
  hec_patient_parametervalues.IsDeleted,
  hec_patient_parameters.GlobalPropertyMatchingID,
  hec_patient_parameters.Modification_Timestamp As Modification_TimestampPatientParameters,
  hec_patient_parametervalues.Modification_Timestamp As Modification_TimestampParameterValues
From
  hec_patient_parameters Inner Join
  hec_patient_parametervalues On hec_patient_parameters.HEC_Patient_ParameterID
    = hec_patient_parametervalues.PatientParameter_RefID
Where
  hec_patient_parametervalues.Tenant_RefID = @Tenant And
  hec_patient_parametervalues.IsDeleted = 0
  