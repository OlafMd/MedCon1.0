
  SELECT
	log_rcp_receipt_positions.ReceiptPosition_Product_RefID,
	cmn_bpt_businessparticipants.DisplayName as SupplierName,
    cmn_bpt_suppliers.CMN_BPT_SupplierID
  FROM log_rcp_receipt_headers 
  INNER JOIN log_rcp_receipt_positions 
    On log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = log_rcp_receipt_positions.Receipt_Header_RefID 
    And log_rcp_receipt_positions.IsDeleted = 0 
    And log_rcp_receipt_positions.Tenant_RefID = @TenantID 
  INNER JOIN cmn_bpt_suppliers 
    On log_rcp_receipt_headers.ProvidingSupplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID 
    And log_rcp_receipt_headers.Tenant_RefID = @TenantID 
  INNER JOIN cmn_bpt_businessparticipants
    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID 
    And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  WHERE
	log_rcp_receipt_headers.Tenant_RefID = @TenantID 
    And log_rcp_receipt_headers.IsDeleted = 0 
    And (@ProvidingSupplier Is Null Or log_rcp_receipt_headers.ProvidingSupplier_RefID = @ProvidingSupplier)
  GROUP BY log_rcp_receipt_positions.ReceiptPosition_Product_RefID, cmn_bpt_suppliers.CMN_BPT_SupplierID
  