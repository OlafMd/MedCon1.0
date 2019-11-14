
	SELECT 
		cmn_bpt_suppliers.CMN_BPT_SupplierID,
		cmn_bpt_businessparticipants.DisplayName,
		cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID AS SupplierType_ID,
		cmn_bpt_supplier_types.GlobalPropertyMatchingID AS SupplierType_GlobalPropertyMatchingID
	FROM 
		cmn_bpt_suppliers
	INNER JOIN cmn_bpt_businessparticipants
		ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
		AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
		AND cmn_bpt_businessparticipants.IsDeleted = 0
	INNER JOIN cmn_bpt_supplier_types
		ON cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID = cmn_bpt_suppliers.SupplierType_RefID
		AND cmn_bpt_supplier_types.IsDeleted = 0
		AND cmn_bpt_supplier_types.Tenant_RefID = @TenantID
	WHERE  
		cmn_bpt_suppliers.IsDeleted = 0
		AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
		AND cmn_bpt_suppliers.Tenant_RefID IS NOT NULL
		AND cmn_bpt_suppliers.SupplierType_RefID !=0x00000000000000000000000000000000
		AND cmn_bpt_suppliers.Tenant_RefID IS NOT NULL;
  