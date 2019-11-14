
	Select
	  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
	  hec_act_performedaction_diagnosisupdates.HEC_Patient_Diagnosis_RefID,
	  hec_act_performedaction_referral_relevantdiagnosisupdates.PerformedAction_Referral_RefID
	From
	  hec_act_performedaction_referral_relevantdiagnosisupdates Inner Join
	  hec_act_performedaction_diagnosisupdates
	    On
	    hec_act_performedaction_referral_relevantdiagnosisupdates.PerformedAction_DiagnosisUpdate_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID Inner Join
	  hec_dia_potentialdiagnoses
	    On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID =
	    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
	Where
	  hec_act_performedaction_referral_relevantdiagnosisupdates.PerformedAction_Referral_RefID = @Referral_RefID And
	  hec_act_performedaction_referral_relevantdiagnosisupdates.Tenant_RefID =
	  @TenantID And
	  hec_act_performedaction_referral_relevantdiagnosisupdates.IsDeleted = 0 And
	  hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
	  hec_dia_potentialdiagnoses.IsDeleted = 0
  