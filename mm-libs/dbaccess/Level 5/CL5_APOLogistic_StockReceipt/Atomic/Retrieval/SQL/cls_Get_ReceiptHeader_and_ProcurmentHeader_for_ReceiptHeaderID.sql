
    SELECT log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID,
           log_rcp_receipt_headers.QualityControlPerformed_AtDate,
           log_rcp_receipt_headers.TakenIntoStock_AtDate,
           ord_prc_procurementorder_headers.ProcurementOrder_Number,
           log_rcp_receipt_headers.IsTakenIntoStock,
           log_rcp_receipt_headers.IsPriceConditionsManuallyCleared,
           log_rcp_receipt_headers.IsReceiptForwardedToBookkeeping,
           log_rcp_receipt_headers.IsQualityControlPerformed,
           log_rcp_receipt_headers.ReceiptNumber,
           log_rcp_receipt_headers.ProvidingSupplier_RefID,
           log_rcp_receipt_headers.PriceConditionsManuallyCleared_ByAccount_RefID,
           log_rcp_receipt_headers.PriceConditionsManuallyCleared_AtDate,
           log_rcp_receipt_headers.TakenIntoStock_ByAccount_RefID,
           log_rcp_receipt_headers.ReceiptForwardedToBookkeeping_ByAccount_RefID,
           log_rcp_receipt_headers.ReceiptForwardedToBookkeeping_AtDate,
           log_rcp_receipt_headers.QualityControlPerformed_ByAccount_RefID
      FROM log_rcp_receipt_headers
           INNER JOIN log_rcp_receiptheader_2_procurementorderheader
              ON     log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID =
                        log_rcp_receiptheader_2_procurementorderheader.LOG_RCP_Receipt_Header_RefID
                 AND log_rcp_receiptheader_2_procurementorderheader.Tenant_RefID =
                        @TenantID
                 AND log_rcp_receiptheader_2_procurementorderheader.IsDeleted = 0
           INNER JOIN ord_prc_procurementorder_headers
              ON     ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
                        log_rcp_receiptheader_2_procurementorderheader.ORD_PRO_ProcurementOrder_Header_RefID
                 AND ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
                 AND ord_prc_procurementorder_headers.IsDeleted = 0
     WHERE     log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID =
                  @ReceiptHeaderID
           AND log_rcp_receipt_headers.Tenant_RefID = @TenantID
           AND log_rcp_receipt_headers.IsDeleted = 0
  