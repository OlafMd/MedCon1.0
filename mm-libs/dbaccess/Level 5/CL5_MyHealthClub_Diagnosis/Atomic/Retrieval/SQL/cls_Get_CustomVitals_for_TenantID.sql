
Select
  hec_patient_parameters.Parameter_Name_DictID,
  hec_patient_parameters.HEC_Patient_ParameterID,
  hec_patient_parametertype_availableunits.Unit_RefID,
  hec_patient_parameters.IfFloat_MinValue,
  hec_patient_parameters.IfFloat_MaxValue
From
  hec_patient_parameters Inner Join
  hec_patient_parametertypes
    On hec_patient_parametertypes.HEC_Patient_ParameterTypeID =
    hec_patient_parameters.ParameterType_RefID Inner Join
  hec_patient_parametertype_2_parametertypegroup
    On
    hec_patient_parametertype_2_parametertypegroup.HEC_Patient_ParameterType_RefID = hec_patient_parametertypes.HEC_Patient_ParameterTypeID Inner Join
  hec_patient_parametertype_groups
    On
    hec_patient_parametertype_2_parametertypegroup.HEC_Patient_ParameterType_Group_RefID = hec_patient_parametertype_groups.HEC_Patient_ParameterType_GroupID Inner Join
  hec_patient_parametertype_availableunits
    On hec_patient_parametertype_availableunits.Patient_ParameterType_RefID =
    hec_patient_parametertypes.HEC_Patient_ParameterTypeID
Where
  hec_patient_parameters.Tenant_RefID = @TenantID And
  hec_patient_parameters.IsDeleted = 0 And
  hec_patient_parametertype_groups.GlobalPropertyMatchingID =
  'myhealtclub.gpapp.group.custom' And
  hec_patient_parametertype_groups.IsDeleted = 0 And
  hec_patient_parametertype_groups.Tenant_RefID = @TenantID And
  hec_patient_parametertype_2_parametertypegroup.IsDeleted = 0 And
  hec_patient_parametertypes.IsDeleted = 0 And
  hec_patient_parametertype_availableunits.IsDeleted = 0 And
  hec_patient_parameters.IsVitalParameter = 1
  