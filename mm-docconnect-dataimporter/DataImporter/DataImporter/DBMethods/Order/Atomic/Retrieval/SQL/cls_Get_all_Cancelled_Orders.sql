
    Select
      ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID as order_header_id
    From
      ord_prc_procurementorder_statuses Inner Join
      ord_prc_procurementorder_headers
        On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
        ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_headers.IsDeleted = 0
    Where
      ord_prc_procurementorder_statuses.Status_Code = 6 And
      ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
      ord_prc_procurementorder_statuses.IsDeleted = 0
  