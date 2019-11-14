
    SELECT 
	    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
        ,ord_prc_procurementorder_headers.ProcurementOrder_Number
	    ,cmn_bpt_businessparticipants.DisplayName AS SupplierName
        ,cmn_bpt_supplier_types.GlobalPropertyMatchingID AS SupplierType
        ,cmn_bpt_suppliers.CMN_BPT_SupplierID
    FROM ord_prc_procurementorder_headers
    INNER JOIN cmn_bpt_suppliers 
        ON ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
	    AND cmn_bpt_suppliers.IsDeleted = 0
	    AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
    INNER JOIN cmn_bpt_businessparticipants 
        ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	    AND cmn_bpt_businessparticipants.IsDeleted = 0
	    AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
    INNER JOIN cmn_bpt_supplier_types 
        ON cmn_bpt_suppliers.SupplierType_RefID = cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
        AND cmn_bpt_supplier_types.IsDeleted = 0
        AND cmn_bpt_supplier_types.Tenant_RefID = @TenantID
    WHERE 
        ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
	    AND ord_prc_procurementorder_headers.IsDeleted = 0
        AND ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID = @ProcurementOrderHeaderID
  