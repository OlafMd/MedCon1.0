
    
Select
  ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID,
  ord_prc_expecteddelivery_headers.ExpectedDeliveryDate,
  ord_prc_expecteddelivery_headers.ExpectedDeliveryNumber,
  ord_prc_expecteddelivery_headers.Creation_Timestamp As
  ExpDeliveryHeader_DateOfCreation,
  ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID,
  ord_prc_expecteddelivery_positions.TotalExpectedQuantity,
  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID,
  log_rcp_receipt_headers.ReceiptNumber,
  log_rcp_receipt_headers.IsTakenIntoStock,
  log_rcp_receipt_headers.IsQualityControlPerformed,
  log_rcp_receipt_headers.IsPriceConditionsManuallyCleared,
  log_rcp_receipt_headers.IsReceiptForwardedToBookkeeping,
  cmn_bpt_suppliers.CMN_BPT_SupplierID,
  cmn_currencies.Symbol As CurrencySymbol,
  cmn_bpt_suppliers.Ext_BusinessParticipant_RefID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_supplier_types.GlobalPropertyMatchingID As SupplierType,
  ord_prc_procurementorder_positions.Position_ValuePerUnit,
  ord_prc_procurementorder_headers.ProcurementOrder_Number,
  cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
From
  ord_prc_expecteddelivery_headers Left Join
  log_rcp_receipt_headers
    On ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID =
    log_rcp_receipt_headers.ExpectedDeliveryHeader_RefID Inner Join
  ord_prc_expecteddelivery_positions
    On ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID =
    ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_RefID Inner Join
  ord_prc_expecteddelivery_2_procurementorderposition
    On ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID =
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ExpectedDelivery_Position_RefID Inner Join
  ord_prc_procurementorder_positions
    On
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
  Inner Join
  cmn_currencies
    On ord_prc_procurementorder_headers.ProcurementOrder_Currency_RefID =
    cmn_currencies.CMN_CurrencyID Left Join
  cmn_bpt_suppliers On log_rcp_receipt_headers.ProvidingSupplier_RefID =
    cmn_bpt_suppliers.CMN_BPT_SupplierID Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
  cmn_bpt_supplier_types On cmn_bpt_suppliers.SupplierType_RefID =
    cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
Where
  ord_prc_expecteddelivery_headers.Tenant_RefID = @TenantID And
  ord_prc_expecteddelivery_headers.IsDeleted = 0 And
  (@SupplierName Is Null Or
    Length(@SupplierName) = 0 Or
    (@SupplierName Is Not Null And
      Lower(cmn_bpt_businessparticipants.DisplayName) Like Concat('%',
      Lower(@SupplierName), '%'))) And
  (@ReceiptNumber Is Null Or
    Length(@ReceiptNumber) = 0 Or
    (@ReceiptNumber Is Not Null And
      Lower(log_rcp_receipt_headers.ReceiptNumber) Like Concat('%',
      Lower(@ReceiptNumber), '%'))) And
  (@ProcurementOrderNumber Is Null Or
    Length(@ProcurementOrderNumber) = 0 Or
    (@ProcurementOrderNumber Is Not Null And
      Lower(ord_prc_procurementorder_headers.ProcurementOrder_Number) Like
      Concat('%', Lower(@ProcurementOrderNumber), '%'))) And
  (@DateFrom Is Null Or
    (@DateFrom Is Not Null And
      log_rcp_receipt_headers.Creation_Timestamp >= @DateFrom)) And
  (@DateTo Is Null Or
    (@DateTo Is Not Null And
      log_rcp_receipt_headers.Creation_Timestamp <= @DateTo)) And
  (@IsQualityControlPerformed Is Null Or
    (@IsQualityControlPerformed Is Not Null And
      log_rcp_receipt_headers.IsQualityControlPerformed =
      @IsQualityControlPerformed)) And
  (@IsTakenIntoStock Is Null Or
    (@IsTakenIntoStock Is Not Null And
      log_rcp_receipt_headers.IsTakenIntoStock = @IsTakenIntoStock)) And
  (@IsPriceConditionsManuallyCleared Is Null Or
    (@IsPriceConditionsManuallyCleared Is Not Null And
      log_rcp_receipt_headers.IsPriceConditionsManuallyCleared =
      @IsPriceConditionsManuallyCleared)) And
  (@IsReceiptForwardedToBookkeeping Is Null Or
    (@IsReceiptForwardedToBookkeeping Is Not Null And
      log_rcp_receipt_headers.IsReceiptForwardedToBookkeeping =
      @IsReceiptForwardedToBookkeeping)) And
  (@SupplierTypeID Is Null Or
    (@SupplierTypeID Is Not Null And
      cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID = @SupplierTypeID))
  