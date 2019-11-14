
    Select
      ord_prc_procurementorder_statuses.Status_Code as OrderStatus
    From
      ord_prc_procurementorder_statushistory
      Inner Join ord_prc_procurementorder_statuses
        On ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID =
        ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
        ord_prc_procurementorder_statuses.IsDeleted = 0 And
        ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_statuses.Status_Code != 6
    Where
      ord_prc_procurementorder_statushistory.Tenant_RefID = @TenantID And
      ord_prc_procurementorder_statushistory.IsDeleted = 0 And
      ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID =
      @HeaderID
    order by
      ord_prc_procurementorder_statushistory.Creation_Timestamp desc
    limit 1
  