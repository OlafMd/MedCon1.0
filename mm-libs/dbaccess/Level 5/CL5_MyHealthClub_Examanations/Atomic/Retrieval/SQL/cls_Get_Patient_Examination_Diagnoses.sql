
	Select
	  hec_dia_potentialdiagnoses.ICD10_Code,
	  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
	  hec_patient_diagnoses.HEC_Patient_DiagnosisID,
	  hec_dia_potentialdiagnoses.PotentialDiagnosisITL,
    hec_act_performedaction_diagnosisupdates.ScheduledExpiryDate
	From
	  hec_act_performedaction_diagnosisupdates Inner Join
	  hec_dia_potentialdiagnoses
	    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
	    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
	    hec_dia_potentialdiagnoses.IsDeleted = 0 And
	    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID Inner Join
	  hec_patient_diagnoses
	    On hec_act_performedaction_diagnosisupdates.HEC_Patient_Diagnosis_RefID =
	    hec_patient_diagnoses.HEC_Patient_DiagnosisID And
	    hec_patient_diagnoses.IsDeleted = 0 And hec_patient_diagnoses.Tenant_RefID =
	    @TenantID And hec_patient_diagnoses.Patient_RefID = @PatientID And
	    hec_patient_diagnoses.R_IsNegated = 0 And hec_patient_diagnoses.R_IsActive =
	    1
	Where
	  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
	  @ExaminationID And
	  hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
	  hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
	  hec_act_performedaction_diagnosisupdates.IsDiagnosisNegated = 0 And
	  hec_act_performedaction_diagnosisupdates.ScheduledExpiryDate > NOW()
  