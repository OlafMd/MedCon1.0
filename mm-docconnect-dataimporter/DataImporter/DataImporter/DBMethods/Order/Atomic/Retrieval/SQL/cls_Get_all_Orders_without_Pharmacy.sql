
Select
  ord_prc_procurementorder_statuses.Status_Code As status,
  ord_prc_procurementorder_headers.ProcurementOrder_Number As number,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID As id
From
  ord_prc_procurementorder_headers Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID = x'00000000000000000000000000000000' And ord_prc_procurementorder_statuses.Status_Code Not
    In (0, 9) And ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And ord_prc_procurementorder_statuses.IsDeleted = 0
Where
  ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_headers.IsDeleted = 0
Order By
  Cast(ord_prc_procurementorder_headers.ProcurementOrder_Number as unsigned)
  