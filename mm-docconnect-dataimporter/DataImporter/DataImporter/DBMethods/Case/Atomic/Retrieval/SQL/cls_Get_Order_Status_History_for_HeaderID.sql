
Select
  ord_prc_procurementorder_statuses.Status_Code as order_status_code
From
  ord_prc_procurementorder_headers Inner Join
  ord_prc_procurementorder_statushistory
    On ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID And
    ord_prc_procurementorder_statushistory.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_statushistory.IsDeleted = 0  
    Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_statuses.IsDeleted = 0
Where
  ord_prc_procurementorder_headers.Tenant_RefID =
  @TenantID And
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID = @HeaderID And
  ord_prc_procurementorder_headers.IsDeleted = 0
Order By
  ord_prc_procurementorder_statushistory.Creation_Timestamp desc
	