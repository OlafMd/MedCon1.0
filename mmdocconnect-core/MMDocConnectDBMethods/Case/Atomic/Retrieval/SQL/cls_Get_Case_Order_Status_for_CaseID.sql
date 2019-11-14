
    Select
      ord_prc_procurementorder_statuses.Status_Code as order_status
    From
      hec_cas_case_relevantperformedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And
        hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedures
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
        hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedure_requiredproduct
        On hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID =
        hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Inner Join
      hec_prc_procurementorder_positions
        On hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID =
        hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And
        hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        hec_prc_procurementorder_positions.IsDeleted = 0 Inner Join
      ord_prc_procurementorder_positions
        On hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And
        ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_positions.IsDeleted = 0
      Inner Join
      ord_prc_procurementorder_headers
        On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID And
        ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_headers.IsDeleted = 0 Inner Join
      ord_prc_procurementorder_statuses
        On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
        ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_statuses.IsDeleted = 0
    Where
      hec_cas_case_relevantperformedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantperformedactions.IsDeleted = 0
	