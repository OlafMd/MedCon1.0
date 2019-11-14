
	Select
	  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_MedicationUpdateID,
	  hec_patient_medications.HEC_Patient_MedicationID,
	  hec_act_performedaction_medicationupdates.DosageText,
	  hec_act_performedaction_medicationupdates.MedicationUpdateComment,
	  cmn_units.ISOCode,
	  hec_sub_substances.HEC_SUB_SubstanceID,
	  hec_sub_substances.IsActiveComponent,
	  hec_act_performedaction_medicationupdates.IfSubstance_Strength,
	  hec_act_performedaction_medicationupdates.Relevant_PatientDiagnosis_RefID,
	  hec_act_performedaction_medicationupdates.IntendedApplicationDuration_in_days,
	  hec_sub_substances.GlobalPropertyMatchingID,
	  hec_act_performedaction_medicationupdates.IsMedicationDeactivated
	From
	  hec_act_performedaction_medicationupdates Inner Join
	  hec_patient_medications
	    On hec_act_performedaction_medicationupdates.HEC_Patient_Medication_RefID =
	    hec_patient_medications.HEC_Patient_MedicationID Inner Join
	  cmn_units On hec_act_performedaction_medicationupdates.IfSubstance_Unit_RefID
	    = cmn_units.CMN_UnitID Inner Join
	  hec_sub_substances
	    On hec_act_performedaction_medicationupdates.IfSubstance_Substance_RefiD =
	    hec_sub_substances.HEC_SUB_SubstanceID
	Where
	  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_RefID =
	  @PerformedActionID And
	  hec_act_performedaction_medicationupdates.Tenant_RefID = @TenantID And
	  hec_act_performedaction_medicationupdates.IsDeleted = 0 And
	  hec_act_performedaction_medicationupdates.IsSubstance = 1 And
	  hec_sub_substances.IsDeleted = 0 And
	  hec_patient_medications.IsDeleted = 0
  