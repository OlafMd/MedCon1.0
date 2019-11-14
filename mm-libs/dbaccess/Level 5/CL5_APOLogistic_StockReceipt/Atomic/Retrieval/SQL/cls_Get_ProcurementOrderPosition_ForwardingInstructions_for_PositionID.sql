
Select
  ord_prc_procurementorder_position_forwardinginstructions.ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID,
  ord_prc_procurementorder_position_forwardinginstructions.QuantityToForward,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  ord_prc_procurementorder_position_forwardinginstructions.ProcurementOrder_Position_RefID,
  cmn_universalcontactdetails.CompanyName_Line1
From
  ord_prc_procurementorder_position_forwardinginstructions Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    ord_prc_procurementorder_position_forwardinginstructions.ForwardTo_BusinessParticipant_RefID Inner Join
  cmn_tenants
    On cmn_tenants.CMN_TenantID =
    cmn_bpt_businessparticipants.IfTenant_Tenant_RefID Inner Join
  cmn_universalcontactdetails On cmn_tenants.UniversalContactDetail_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID
Where
  ord_prc_procurementorder_position_forwardinginstructions.ProcurementOrder_Position_RefID = @PRCPositionID And
  ord_prc_procurementorder_position_forwardinginstructions.IsDeleted = 0 And
  cmn_tenants.IsDeleted = 0 And
  ord_prc_procurementorder_position_forwardinginstructions.Tenant_RefID =
  @TenantID
  
  