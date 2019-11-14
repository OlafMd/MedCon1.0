
	Select
	  hec_patient_parameters.HEC_Patient_ParameterID,
	  hec_patient_parameters.PatientParameterITL,
	  hec_patient_parameters.GlobalPropertyMatchingID,
	  hec_patient_parameters.Parameter_Name_DictID,
	  hec_patient_parameters.IsFloat,
	  hec_patient_parameters.IsFloat_ApplicableUnit_RefID,
	  hec_patient_parameters.IsString,
	  hec_patient_parameters.IsVitalParameter,
	  hec_patient_parameters.Creation_Timestamp,
	  hec_patient_parameters.Tenant_RefID,
	  hec_patient_parameters.IsDeleted,
	  hec_patient_parameters.HasHighRelevance,
	  hec_patient_parameters.Modification_Timestamp,
	  hec_patient_parameters.ParameterType_RefID,
	  hec_patient_parametertypes.HEC_Patient_ParameterTypeID,
	  hec_patient_parametertypes.GlobalPropertyMatchingID As
	  GlobalPropertyMatchingIDParameterTypes,
	  hec_patient_parametertypes.Name_DictID,
	  hec_patient_parametertypes.Creation_Timestamp As
	  Creation_TimestampParameterTypes,
	  hec_patient_parametertypes.IsDeleted As IsDeletedParameterTypes,
	  hec_patient_parametertypes.Modification_Timestamp As
	  Modification_TimestampParameterTypes,
    hec_patient_parameters.IfFloat_MinValue,
    hec_patient_parameters.IfFloat_MaxValue
	From
	  hec_patient_parametertypes Inner Join
	  hec_patient_parameters On hec_patient_parameters.ParameterType_RefID =
	    hec_patient_parametertypes.HEC_Patient_ParameterTypeID
	Where
	  hec_patient_parametertypes.Tenant_RefID = @Tenant
  