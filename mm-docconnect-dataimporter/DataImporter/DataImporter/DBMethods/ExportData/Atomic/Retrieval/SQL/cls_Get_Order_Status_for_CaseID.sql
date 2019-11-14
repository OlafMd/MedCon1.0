
Select
  hec_cas_case_relevantplannedactions.PlannedAction_RefID,
  ord_prc_procurementorder_positions.Tenant_RefID,
  hec_cas_cases.HEC_CAS_CaseID,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID As OrderID,
  ord_prc_procurementorder_statushistory.Modification_Timestamp As
  StatusModified,
  ord_prc_procurementorder_statushistory.IsStatus_Canceled As StatusCanceled,
  ord_prc_procurementorder_statushistory.ORD_PRC_ProcurementOrder_StatusHistoryID As StatusHistoryID,
  hec_cas_cases.Patient_RefID,
  ord_prc_procurementorder_statuses.Status_Code as StatusCode,
  ord_prc_procurementorder_statushistory.Creation_Timestamp as StatusCreated
From
  hec_cas_cases Left Join
  hec_cas_case_relevantplannedactions
    On hec_cas_case_relevantplannedactions.Case_RefID =
    hec_cas_cases.HEC_CAS_CaseID Left Join
  hec_act_plannedaction_2_actiontype
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
    hec_act_plannedaction_2_actiontype.Tenant_RefID =
    @TenantID And
    hec_act_plannedaction_2_actiontype.IsDeleted = 0 Left Join
  hec_act_actiontype
    On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID =
    hec_act_actiontype.HEC_ACT_ActionTypeID And hec_act_actiontype.Tenant_RefID
    = @TenantID And hec_act_actiontype.Tenant_RefID =
    @TenantID Left Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID =
    hec_cas_case_relevantplannedactions.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.IsDeleted = 0 And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID =
    @TenantID Left Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID Left Join
  hec_prc_procurementorder_positions
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.IsDeleted = 0 And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID Left Join
  ord_prc_procurementorder_positions
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.IsDeleted = 0 And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID Left Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.IsDeleted = 0 And
    ord_prc_procurementorder_headers.Tenant_RefID =
    @TenantID Left Join
  ord_prc_procurementorder_statushistory
    On ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
  Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID =
    ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID
Where
  hec_cas_cases.HEC_CAS_CaseID = @CaseID And
  hec_cas_cases.Tenant_RefID = @TenantID And
  hec_act_actiontype.GlobalPropertyMatchingID =
  'mm.docconect.doc.app.planned.action.treatment'
Group By
  hec_cas_cases.HEC_CAS_CaseID,
  ord_prc_procurementorder_statushistory.IsStatus_Canceled,
  ord_prc_procurementorder_statushistory.Modification_Timestamp,
  ord_prc_procurementorder_statushistory.Creation_Timestamp
    
    
  