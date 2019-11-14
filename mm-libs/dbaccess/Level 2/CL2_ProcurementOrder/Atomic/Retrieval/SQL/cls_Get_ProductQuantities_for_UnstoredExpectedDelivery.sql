
	Select
	  Sum(ord_prc_expecteddelivery_positions.TotalExpectedQuantity) As
	  TotalExpectedQuantity,
	  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID
	From
	  ord_prc_expecteddelivery_positions Inner Join
	  ord_prc_expecteddelivery_headers
	    On ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_RefID =
	    ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID
	  Inner Join
	  log_rcp_receipt_headers
	    On log_rcp_receipt_headers.ExpectedDeliveryHeader_RefID =
	    ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID
	  Inner Join
	  log_rcp_receiptheader_2_procurementorderheader
	    On
	    log_rcp_receiptheader_2_procurementorderheader.LOG_RCP_Receipt_Header_RefID
	    = log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID Inner Join
	  ord_prc_procurementorder_headers
	    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
	    log_rcp_receiptheader_2_procurementorderheader.ORD_PRO_ProcurementOrder_Header_RefID Inner Join
	  ord_prc_expecteddelivery_2_procurementorderposition
	    On
	    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ExpectedDelivery_Position_RefID = ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID Inner Join
	  ord_prc_procurementorder_positions
	    On
	    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
	Where
	  ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
	  ord_prc_procurementorder_headers.IsDeleted = 0 And
	  log_rcp_receiptheader_2_procurementorderheader.IsDeleted = 0 And
	  log_rcp_receipt_headers.IsDeleted = 0 And
	  ord_prc_expecteddelivery_headers.IsDeleted = 0 And
	  ord_prc_expecteddelivery_positions.IsDeleted = 0 And
	  ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
	  @OrderedProcurementStatusID And
	  ord_prc_expecteddelivery_headers.ExpectedDeliveryDate <= @ExpectedDateBefore
	  And
	  log_rcp_receipt_headers.IsTakenIntoStock = 0 And
	  ord_prc_expecteddelivery_2_procurementorderposition.IsDeleted = 0 And
	  ord_prc_procurementorder_positions.IsDeleted = 0
	Group By
	  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID
  