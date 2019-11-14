
Select
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_patient_diagnoses.R_ScheduledExpiryDate,
  hec_patient_diagnoses.HEC_Patient_DiagnosisID,
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID,
  hec_dia_potentialdiagnoses.PotentialDiagnosisITL
From
  hec_patient_diagnoses Inner Join
  hec_dia_potentialdiagnoses On hec_patient_diagnoses.R_PotentialDiagnosis_RefID
    = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID Inner Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
    hec_act_performedaction_diagnosisupdates.IsDeleted = 0
Where
  hec_patient_diagnoses.R_ScheduledExpiryDate > CurDate() And
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
  @ExaminationID And
  hec_patient_diagnoses.R_IsActive = 1 And
  hec_patient_diagnoses.Patient_RefID = @PatientID And
  hec_patient_diagnoses.IsDeleted = 0 And
  hec_patient_diagnoses.Tenant_RefID = @TenantID And
  hec_patient_diagnoses.R_IsNegated = 0
  