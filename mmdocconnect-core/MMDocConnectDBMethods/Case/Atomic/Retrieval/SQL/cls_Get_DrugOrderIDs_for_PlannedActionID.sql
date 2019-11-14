
Select
  hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID,
  hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID,
  ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID,
  hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID
From
  hec_act_plannedaction_potentialprocedures Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0 Inner Join
  hec_prc_procurementorder_positions
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And hec_prc_procurementorder_positions.IsDeleted = 0 Inner Join
  ord_prc_procurementorder_positions
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_headers.IsDeleted = 0
Where
  hec_act_plannedaction_potentialprocedures.PlannedAction_RefID =
  @PlannedActionID And
  hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And
  hec_act_plannedaction_potentialprocedures.IsDeleted = 0
	