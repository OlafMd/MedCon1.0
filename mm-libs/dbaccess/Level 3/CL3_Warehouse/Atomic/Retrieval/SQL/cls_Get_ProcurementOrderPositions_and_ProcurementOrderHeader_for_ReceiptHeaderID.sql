
Select
  ord_prc_procurementorder_positions.Position_ValueTotal,
  ord_prc_procurementorder_headers.ProcurementOrder_Currency_RefID,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID,
  ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID,
  log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
From
  log_rcp_receiptposition_2_procurementorderposition Inner Join
  log_rcp_receipt_positions
    On log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID =
    log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID Inner Join
  ord_prc_procurementorder_positions
    On
    log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
Where
  log_rcp_receipt_positions.Receipt_Header_RefID = @ReceiptHeaderID And
  log_rcp_receipt_positions.Tenant_RefID = @TenantID And
  log_rcp_receipt_positions.IsDeleted = 0
  