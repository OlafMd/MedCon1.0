
    Select
      hec_act_plannedactions.PlannedFor_Date As treatment_date
    From
      ord_prc_procurementorder_positions Inner Join
      hec_prc_procurementorder_positions
        On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID = hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID
        And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_potentialprocedure_requiredproduct
        On hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID =
        hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
      Inner Join
      hec_act_plannedaction_potentialprocedures
        On hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID =
        hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
        And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
      hec_act_plannedactions
        On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Tenant_RefID =
        @TenantID And hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions.IsDeleted = 0 
    Where
      ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = @OrderIDs And
      ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
      ord_prc_procurementorder_positions.IsDeleted = 0
  