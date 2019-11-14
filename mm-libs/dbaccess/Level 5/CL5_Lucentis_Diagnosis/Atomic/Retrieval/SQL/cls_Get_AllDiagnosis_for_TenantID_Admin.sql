
	Select
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Description_DictID,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  States.DiagnosisState_Name_DictID,
  States.DiagnosisState_Abbreviation,
  States.HEC_DIA_Diagnosis_StateID,
  Localization.DiagnosisLocalization_Name_DictID,
  Localization.HEC_DIA_Diagnosis_LocalizationID
From
  hec_dia_potentialdiagnoses Left Join
  (Select
    hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
    hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
    hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
    hec_dia_diagnosis_states.Diagnose_RefID
  From
    hec_dia_diagnosis_states
  Where
    hec_dia_diagnosis_states.IsDeleted = 0) States
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    States.Diagnose_RefID Left Join
  (Select
    hec_dia_diagnosis_localizations.DiagnosisLocalization_Name_DictID,
    hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID,
    hec_dia_diagnosis_localizations.Diagnosis_RefID
  From
    hec_dia_diagnosis_localizations
  Where
    hec_dia_diagnosis_localizations.IsDeleted = 0) Localization
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    Localization.Diagnosis_RefID
Where
  hec_dia_potentialdiagnoses.IsDeleted = 0 And
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID
  