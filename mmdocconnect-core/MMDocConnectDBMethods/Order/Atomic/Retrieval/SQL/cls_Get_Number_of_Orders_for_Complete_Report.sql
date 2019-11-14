
  Select
      Count(ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID) As
      number_of_tiles
    From
      ord_prc_procurementorder_statuses
      Inner Join ord_prc_procurementorder_headers
        On ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID =
        ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID And
        ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_headers.IsDeleted = 0
    Where
      ord_prc_procurementorder_statuses.Status_Code in (1, 2, 3, 4, 6, 7, 10) And
      ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
      ord_prc_procurementorder_statuses.IsDeleted = 0
  