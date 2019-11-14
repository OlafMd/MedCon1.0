
	SELECT
		ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
	FROM
		ord_prc_procurementorder_headers
	INNER JOIN ord_prc_procurementorder_statuses
		ON ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID = ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID
		AND ord_prc_procurementorder_statuses.IsDeleted = 0
		AND ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID
		AND ord_prc_procurementorder_statuses.GlobalPropertyMatchingID = @ActiveStatus_GlobalPropertyMatchingID
	WHERE
		ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID = @SupplierID
		AND ord_prc_procurementorder_headers.IsDeleted = 0
		AND ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
  