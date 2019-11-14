

     SELECT MAX(CONVERT(ord_prc_procurementorder_headers.ProcurementOrder_Number, SIGNED)) AS  latest_order_number
    From
      ord_prc_procurementorder_headers
    Where
     ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
  