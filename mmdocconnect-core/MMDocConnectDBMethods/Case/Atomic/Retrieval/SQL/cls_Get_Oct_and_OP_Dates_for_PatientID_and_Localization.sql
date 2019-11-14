
    (Select
        hec_act_performedactions.IfPerfomed_DateOfAction As TreatmentDate,        
        0 as IsOp,
        0 as IsOpPerformed
      From
        hec_act_performedactions Inner Join
        hec_act_performedaction_diagnosisupdates
          On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
          hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
          hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
        hec_act_performedaction_diagnosisupdate_localizations
          On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
          hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
          hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @Localization And
    	    hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
    	    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
        hec_act_performedaction_2_actiontype
          On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID And
          hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
          hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
        hec_act_actiontype
          On hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And
    	    hec_act_actiontype.GlobalPropertyMatchingID = 'mm.docconect.doc.app.performed.action.oct' And
    	    hec_act_actiontype.Tenant_RefID = @TenantID And
    	    hec_act_actiontype.IsDeleted = 0
      Where
        hec_act_performedactions.Patient_RefID = @PatientID And
        hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0
       Order By
        TreatmentDate)
      union All
      (Select
          hec_act_plannedactions.PlannedFor_Date as TreatmentDate,
          1 As IsOp,
          hec_act_plannedactions.IsPerformed as IsOpPerformed
        From
          hec_cas_case_relevantperformedactions Inner Join
          hec_act_performedaction_diagnosisupdates
            On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
            hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And 
            hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
          hec_act_performedaction_diagnosisupdate_localizations
            On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
            hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
            hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code = @Localization And
            hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
            hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
          hec_act_plannedactions
            On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
            hec_act_plannedactions.Patient_RefID = @PatientID And
            hec_act_plannedactions.Tenant_RefID = @TenantID And
            hec_act_plannedactions.IsDeleted = 0
        Where
	        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
	        hec_cas_case_relevantperformedactions.IsDeleted = 0
        Order By
          TreatmentDate)
	