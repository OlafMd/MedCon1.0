
    Select
  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  hec_product_dosageforms.DosageForm_Name_DictID,
  hec_product_dosageforms.GlobalPropertyMatchingID,
  cmn_units.Abbreviation_DictID,
  cmn_units.ISOCode,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  ord_prc_procurementorder_positions.Position_Quantity,
  log_rcp_receipt_positions.TotalQuantityTakenIntoStock,
  log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID,
  ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
From
  log_rcp_receipt_positions Inner Join
  log_rcp_receipt_headers On log_rcp_receipt_positions.Receipt_Header_RefID =
    log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID And
    log_rcp_receipt_positions.Tenant_RefID = @TenantID And
    log_rcp_receipt_positions.IsDeleted = 0 Left Join
  log_rcp_receiptposition_2_procurementorderposition
    On log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID =
    log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID And log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = @TenantID And log_rcp_receiptposition_2_procurementorderposition.IsDeleted = 0 Left Join
  ord_prc_procurementorder_positions
    On
    log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.IsDeleted = 0 Inner Join
  cmn_pro_products On log_rcp_receipt_positions.ReceiptPosition_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.Tenant_RefID =
    @TenantID And cmn_pro_products.IsDeleted = 0 Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And hec_products.Tenant_RefID = @TenantID
    And hec_products.IsDeleted = 0 Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID
Where
  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = @HeaderID And
  log_rcp_receipt_headers.Tenant_RefID = @TenantID And
  log_rcp_receipt_headers.IsDeleted = 0 And
  log_rcp_receipt_positions.IsDeleted = 0
  