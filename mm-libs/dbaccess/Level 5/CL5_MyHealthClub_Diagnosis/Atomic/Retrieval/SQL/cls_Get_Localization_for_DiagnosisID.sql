
	Select
	  hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID,
	  hec_dia_diagnosis_localizations.DiagnosisLocalization_Name_DictID
	From
	  hec_dia_diagnosis_localizations
	Where
	  hec_dia_diagnosis_localizations.IsDeleted = 0 And
	  hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And
	  hec_dia_diagnosis_localizations.Diagnosis_RefID = @DiagnosisID
  