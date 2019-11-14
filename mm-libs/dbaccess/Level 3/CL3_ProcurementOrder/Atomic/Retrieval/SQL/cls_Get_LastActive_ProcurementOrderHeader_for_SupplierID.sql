

Select
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID,
  ord_prc_procurementorder_headers.Creation_Timestamp
From
  ord_prc_procurementorder_headers Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID =
    ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID And
    ord_prc_procurementorder_statuses.IsDeleted = 0 And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_statuses.GlobalPropertyMatchingID =
    @ActiveStatus_GlobalPropertyMatchingID
 Where
  ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID = @SupplierID
  And
  ord_prc_procurementorder_headers.IsDeleted = 0 And
  ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
Order By
  ord_prc_procurementorder_headers.Creation_Timestamp Desc limit 1
  