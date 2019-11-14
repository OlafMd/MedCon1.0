
    Select
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosisCatalog_Name as diagnose_catalog_name,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosis_Code as diagnose_code,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosis_Name as diagnose_name,
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID as diagnose_id,
      hec_cas_case_relevantperformedactions.Case_RefID as case_id
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0      
    Where
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	