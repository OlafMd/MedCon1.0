
    Select
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
      hec_act_performedactions.Patient_RefID As patient_id,
      hec_act_performedactions.IfPerfomed_DateOfAction As performed_on_date
    From
      hec_act_performedactions Inner Join
      hec_act_performedaction_2_actiontype
        On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_2_actiontype.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_performedaction_2_actiontype.IsDeleted = 0 Inner Join
      hec_act_actiontype
        On hec_act_performedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype.HEC_ACT_ActionTypeID And
  	    hec_act_actiontype.GlobalPropertyMatchingID = @ActionTypeGpmID And
        hec_act_actiontype.Tenant_RefID = @TenantID And
        hec_act_actiontype.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_act_performedactions.HEC_ACT_PerformedActionID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
    Where
      hec_act_performedactions.Tenant_RefID = @TenantID And
      hec_act_performedactions.IsDeleted = 0 
    Order by performed_on_date desc
	