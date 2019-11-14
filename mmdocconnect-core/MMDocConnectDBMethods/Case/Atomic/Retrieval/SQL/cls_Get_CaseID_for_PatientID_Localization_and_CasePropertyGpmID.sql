
    Select
      hec_cas_cases.HEC_CAS_CaseID as case_id
    From
      hec_cas_cases Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
        hec_cas_case_relevantperformedactions.IsDeleted = 0 Inner Join
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
      hec_cas_case_universalpropertyvalue
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
        hec_cas_case_universalpropertyvalue.IsDeleted = 0 Inner Join
      hec_cas_case_universalproperties
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
  	    hec_cas_case_universalproperties.GlobalPropertyMatchingID = @CasePropertyGpmID And
  	    hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
  	    hec_cas_case_universalproperties.IsDeleted = 0
    Where
      hec_cas_cases.Patient_RefID = @PatientID And
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
	