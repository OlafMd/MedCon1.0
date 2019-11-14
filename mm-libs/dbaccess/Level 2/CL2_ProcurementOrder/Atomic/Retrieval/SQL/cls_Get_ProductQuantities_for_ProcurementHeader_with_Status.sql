
	Select
	  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID,
	  Sum(ord_prc_procurementorder_positions.Position_Quantity) As Quantity
	From
	  ord_prc_procurementorder_headers Inner Join
	  ord_prc_procurementorder_positions
	    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
	    ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID
	Where
	  ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
	  @CurrentProcurementOrderStatus And
	  ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
	Group By
	  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID
  