
    Select
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
      hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As is_label_only,
      hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As is_patient_fee_waived,
      hec_cas_case_universalpropertyvalue.Value_Boolean As is_send_invoice_to_practice,
      hec_act_plannedactions.PlannedFor_Date as treatment_date
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
        hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedures
        On hec_act_plannedactions.HEC_ACT_PlannedActionID =
        hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
        hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
        And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedure_requiredproduct
        On
        hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Inner Join
      hec_prc_procurementorder_positions
        On
        hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Inner Join
      ord_prc_procurementorder_positions
        On
        hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Inner Join
      hec_cas_case_universalpropertyvalue
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID =
        hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
        hec_cas_case_universalpropertyvalue.IsDeleted = 0 Inner Join
      hec_cas_case_universalproperties
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID
        = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
        hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
        hec_cas_case_universalproperties.IsDeleted = 0 And
        hec_cas_case_universalproperties.IsValue_Boolean = 1   And
        hec_cas_case_universalproperties.GlobalPropertyMatchingID =  'mm.doc.connect.case.practice.invoice'
    Where
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0 And
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseID 
	