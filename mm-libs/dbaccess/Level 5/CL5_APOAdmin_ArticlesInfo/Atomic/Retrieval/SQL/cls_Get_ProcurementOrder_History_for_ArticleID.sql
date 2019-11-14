
Select 
  ord_prc_procurementorder_headers.ProcurementOrder_Number,
  ord_prc_procurementorder_positions.Position_ValuePerUnit,
  ord_prc_procurementorder_positions.Position_Quantity,
  supplier.DisplayName Supplier,
  creator.DisplayName Creator,
  ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery,
  ord_prc_expecteddelivery_headers.ExpectedDeliveryDate,
  log_rcp_receipt_headers.TakenIntoStock_AtDate,
  log_rcp_receipt_headers.IsTakenIntoStock
From
  ord_prc_procurementorder_positions Left Join
  ord_prc_expecteddelivery_2_procurementorderposition
    On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID =
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID Left Join
  ord_prc_expecteddelivery_positions
    On ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID =
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ExpectedDelivery_Position_RefID Left Join
  ord_prc_expecteddelivery_headers
    On ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID =
    ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_RefID Left Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants creator
    On ord_prc_procurementorder_headers.CreatedBy_BusinessParticipant_RefID =
    creator.CMN_BPT_BusinessParticipantID And creator.IsDeleted = 0 Left Join
  cmn_bpt_suppliers
    On ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID =
    cmn_bpt_suppliers.CMN_BPT_SupplierID And cmn_bpt_suppliers.IsDeleted = 0
  Left Join
  cmn_bpt_businessparticipants supplier
    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
    supplier.CMN_BPT_BusinessParticipantID And supplier.IsDeleted = 0 Left Join
  log_rcp_receipt_headers
    On ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID =
    log_rcp_receipt_headers.ExpectedDeliveryHeader_RefID
Where
  ord_prc_procurementorder_positions.IsDeleted = 0 And
  ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID =  @ArticleID
  