
Select
  hec_patient_parametervalues.HEC_Patient_ParameterValueID,
  hec_patient_parameters.HEC_Patient_ParameterID,
  hec_patient_parameters.IsVitalParameter,
  hec_patient_parametervalues.StringValue,
  hec_patient_parametervalues.IsConfirmed,
  hec_patient_parametervalues.ConfirmedBy_Doctor_RefID,
  hec_patient_parametervalues.DateOfValue,
  hec_patient_parametervalues.DateOfEntry
From
  hec_act_performedaction_patientparameters Inner Join
  hec_patient_parametervalues
    On
    hec_act_performedaction_patientparameters.HEC_Patient_ParameterValue_RefID =
    hec_patient_parametervalues.HEC_Patient_ParameterValueID Inner Join
  hec_patient_parameters On hec_patient_parametervalues.PatientParameter_RefID =
    hec_patient_parameters.HEC_Patient_ParameterID
Where
  hec_act_performedaction_patientparameters.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID And
  hec_act_performedaction_patientparameters.IsDeleted = 0 And
  hec_act_performedaction_patientparameters.Tenant_RefID = @TenantID And
  hec_patient_parametervalues.IsDeleted = 0 And
  hec_patient_parameters.IsDeleted = 0
Order By
  hec_act_performedaction_patientparameters.Creation_Timestamp Desc
  