
Select
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID As order_id,
  hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As drug_id,
  hec_act_plannedactions.PlannedFor_Date As treatment_date,
  hec_act_plannedactions.Patient_RefID as patient_id
From
  ord_prc_procurementorder_headers Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And ord_prc_procurementorder_statuses.IsDeleted = 0 Inner Join
  ord_prc_procurementorder_positions
    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID = ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID And
    ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Inner Join
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
    On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And 
    hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions.IsPerformed = 0 And hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Left Join
  hec_act_performedaction_diagnosisupdates
    On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0
Where
  hec_act_plannedactions.Patient_RefID = @PatientIDs And 
  ord_prc_procurementorder_statuses.Status_Code In (1, 2, 3) And
  ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_statuses.IsDeleted = 0 And
  hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID Is Null
  