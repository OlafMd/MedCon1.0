
Select
  hec_patient_parametervalues.StringValue,
  hec_patient_parameters.GlobalPropertyMatchingID,
  hec_patient_parameters.HEC_Patient_ParameterID
From
  hec_act_performedaction_patientparameters Inner Join
  hec_patient_parametervalues
    On hec_patient_parametervalues.HEC_Patient_ParameterValueID =
    hec_act_performedaction_patientparameters.HEC_Patient_ParameterValue_RefID
  Inner Join
  hec_patient_parameters On hec_patient_parameters.HEC_Patient_ParameterID =
    hec_patient_parametervalues.PatientParameter_RefID
Where
  hec_act_performedaction_patientparameters.HEC_ACT_PerformedAction_RefID =
  @ExaminationID And
  hec_act_performedaction_patientparameters.IsDeleted = 0 And
  hec_patient_parametervalues.IsDeleted = 0 And
  hec_act_performedaction_patientparameters.Tenant_RefID = @TenantID
  