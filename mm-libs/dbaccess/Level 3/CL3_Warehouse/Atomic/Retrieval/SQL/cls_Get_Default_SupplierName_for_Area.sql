
SELECT cmn_bpt_businessparticipants.DisplayName AreaSupplierName, 
log_wrh_area_defaultSuppliers.CMN_BPT_Supplier_RefID
FROM log_wrh_area_defaultSuppliers
INNER JOIN CMN_BPT_Suppliers ON log_wrh_area_defaultsuppliers.CMN_BPT_Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
	AND cmn_bpt_suppliers.IsDeleted = 0
INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	AND cmn_bpt_businessparticipants.IsDeleted = 0
WHERE log_wrh_area_defaultSuppliers.Area_RefID = @AreaID
	AND log_wrh_area_defaultsuppliers.Tenant_RefID = @TenantID
	AND log_wrh_area_defaultsuppliers.IsDeleted = 0
  