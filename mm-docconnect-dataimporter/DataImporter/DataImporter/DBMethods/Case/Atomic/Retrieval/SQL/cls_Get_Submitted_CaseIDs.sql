
    Select
      hec_cas_cases.HEC_CAS_CaseID As case_id,
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As gpos_type,
      hec_cas_cases.CaseNumber As case_number
    From
      hec_cas_cases Left Join
      hec_cas_case_relevantplannedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID Left Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID Inner Join
      hec_cas_case_billcodes
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID Inner Join
      hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID Inner Join
      hec_bil_potentialcodes
        On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID Inner Join
      hec_bil_potentialcode_catalogs
        On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID Inner Join
      hec_cas_case_relevantperformedactions
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID Inner Join
      hec_act_plannedactions hec_act_plannedactions1
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions1.IfPlannedFollowup_PreviousAction_RefID
    Where
      hec_cas_case_billcodes.Tenant_RefID = @TenantID And
      hec_cas_case_billcodes.IsDeleted = 0 And
      Cast(hec_cas_cases.CaseNumber As Unsigned) > 9999 And
      hec_act_plannedactions1.IsPerformed = 1
    Order By
      Cast(hec_cas_cases.CaseNumber as unsigned)
	