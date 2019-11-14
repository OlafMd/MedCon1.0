
	SELECT cmn_bpt_businessparticipants.DisplayName RackSupplierName,
  log_wrh_rack_defaultsuppliers.CMN_BPT_Supplier_RefID
	FROM log_wrh_rack_defaultsuppliers
	INNER JOIN CMN_BPT_Suppliers ON log_wrh_rack_defaultsuppliers.CMN_BPT_Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
		AND CMN_BPT_Suppliers.IsDeleted = 0
	INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
		AND cmn_bpt_businessparticipants.IsDeleted = 0
	WHERE log_wrh_rack_defaultsuppliers.Rack_RefID = @RackID
		AND log_wrh_rack_defaultsuppliers.Tenant_RefID = @TenantID 
		AND log_wrh_rack_defaultsuppliers.IsDeleted = 0
  