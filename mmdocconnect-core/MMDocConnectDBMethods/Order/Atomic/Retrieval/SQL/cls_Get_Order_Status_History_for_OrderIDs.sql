
Select
  ord_prc_procurementorder_statuses.Status_Code As StatusCode,
  ord_prc_procurementorder_statuses.GlobalPropertyMatchingID As StatusGPMID,
  ord_prc_procurementorder_statuses.Creation_Timestamp As StatusChangedOn,
  ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID As OrderID
From
  ord_prc_procurementorder_statushistory Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_statuses.IsDeleted = 0
Where
  ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID = @OrderIDs And
  ord_prc_procurementorder_statushistory.Tenant_RefID = @TenantID And
  ord_prc_procurementorder_statushistory.IsDeleted = 0
  