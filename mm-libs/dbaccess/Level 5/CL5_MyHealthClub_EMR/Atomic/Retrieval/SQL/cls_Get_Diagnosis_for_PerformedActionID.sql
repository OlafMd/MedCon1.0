
Select
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID,
  hec_patient_diagnoses.HEC_Patient_DiagnosisID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_patient_diagnoses.R_DiagnosedOnDate,
  hec_patient_diagnoses.R_ScheduledExpiryDate,
  hec_patient_diagnoses.R_IsActive,
  hec_patient_diagnoses.R_IsConfirmed,
  hec_patient_diagnoses.R_IsNegated,
  hec_patient_diagnoses.R_IsAssumed,
  hec_patient_diagnoses.R_DeactivatedOnDate
From
  hec_act_performedaction_diagnosisupdates Inner Join
  hec_patient_diagnoses
    On hec_act_performedaction_diagnosisupdates.HEC_Patient_Diagnosis_RefID =
    hec_patient_diagnoses.HEC_Patient_DiagnosisID Inner Join
  hec_dia_potentialdiagnoses
    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
Where
  hec_patient_diagnoses.IsDeleted = 0 And
  hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
  hec_dia_potentialdiagnoses.IsDeleted = 0 And
  hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID
  