
Select
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
  hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
  hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
  hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID,
  hec_dia_diagnosis_localizations.DiagnosisLocalization_Name_DictID,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID
From
  hec_dia_diagnosis_localizations Inner Join
  hec_dia_potentialdiagnoses
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_diagnosis_localizations.Diagnosis_RefID Inner Join
  hec_dia_diagnosis_states On hec_dia_diagnosis_states.Diagnose_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
Where
  hec_dia_potentialdiagnoses.IsDeleted = 0 And
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
  hec_dia_diagnosis_localizations.IsDeleted = 0 And
  hec_dia_diagnosis_states.IsDeleted = 0 And
  hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And
  hec_dia_diagnosis_states.Tenant_RefID = @TenantID
  