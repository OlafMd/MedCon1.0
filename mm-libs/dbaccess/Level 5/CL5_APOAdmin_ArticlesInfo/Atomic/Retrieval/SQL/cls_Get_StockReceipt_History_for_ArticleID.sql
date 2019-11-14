
Select
  ord_prc_procurementorder_headers.ProcurementOrder_Number,
  log_rcp_receipt_headers.TakenIntoStock_AtDate,
  ord_prc_procurementorder_positions.Position_Quantity,
  ord_prc_procurementorder_positions.Position_ValueTotal,
  creator.DisplayName Creator,
  supplier.DisplayName Supplier,
  log_rcp_receipt_headers.ReceiptNumber
From
  ord_prc_procurementorder_positions Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.IsDeleted = 0 Inner Join
  log_rcp_receiptheader_2_procurementorderheader
    On
    log_rcp_receiptheader_2_procurementorderheader.ORD_PRO_ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID And log_rcp_receiptheader_2_procurementorderheader.IsDeleted = 0 Inner Join
  log_rcp_receipt_headers
    On
    log_rcp_receiptheader_2_procurementorderheader.LOG_RCP_Receipt_Header_RefID
    = log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID And
    log_rcp_receipt_headers.IsDeleted = 0 Inner Join
  log_rcp_receipt_positions
    On log_rcp_receipt_positions.ReceiptPosition_Product_RefID =
    ord_prc_procurementorder_positions.CMN_PRO_Product_RefID And
    log_rcp_receipt_positions.Receipt_Header_RefID =
    log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID And
    log_rcp_receipt_positions.IsDeleted = 0 Inner Join
  usr_accounts
    On log_rcp_receipt_headers.QualityControlPerformed_ByAccount_RefID =
    usr_accounts.USR_AccountID Inner Join
  cmn_bpt_businessparticipants creator On usr_accounts.BusinessParticipant_RefID
    = creator.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_suppliers On log_rcp_receipt_headers.ProvidingSupplier_RefID =
    cmn_bpt_suppliers.CMN_BPT_SupplierID Inner Join
  cmn_bpt_businessparticipants supplier
    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
    supplier.CMN_BPT_BusinessParticipantID
Where
  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID = @ArticleID And
  ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_positions.IsDeleted = 0
  