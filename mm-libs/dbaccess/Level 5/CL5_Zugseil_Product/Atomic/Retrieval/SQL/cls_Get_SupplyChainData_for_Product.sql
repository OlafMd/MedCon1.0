
	SELECT cmn_economicregion.EconomicRegion_Name_DictID
		,cmn_economicregion.ParentEconomicRegion_RefID
		,cmn_economicregion.CMN_EconomicRegionID
		,log_wrh_warehouses.LOG_WRH_WarehouseID
		,log_wrh_warehouses.Warehouse_Name
		,cmn_bpt_suppliers.CMN_BPT_SupplierID
		,cmn_bpt_suppliers.ExternalSupplierProvidedIdentifier
		,cmn_bpt_businessparticipants.DisplayName
    ,cmn_pro_product_suppliers.CMN_PRO_Product_SupplierID
	FROM cmn_economicregion
	LEFT JOIN cmn_pro_distributioncenters ON cmn_economicregion.CMN_EconomicRegionID = cmn_pro_distributioncenters.EconomicRegion_RefID
		AND cmn_pro_distributioncenters.Product_RefID = @ProductID
		AND cmn_pro_distributioncenters.IsDeleted = 0
		AND cmn_pro_distributioncenters.Tenant_RefID = @TenantID
	LEFT JOIN log_wrh_warehouses ON cmn_pro_distributioncenters.Warehouse_RefID = log_wrh_warehouses.LOG_WRH_WarehouseID
		AND log_wrh_warehouses.IsDeleted = 0
		AND log_wrh_warehouses.Tenant_RefID = @TenantID
	LEFT JOIN cmn_pro_product_supplier_regionalbindings ON cmn_economicregion.CMN_EconomicRegionID = cmn_pro_product_supplier_regionalbindings.EconomicRegion_RefID
		AND cmn_pro_product_supplier_regionalbindings.IsDeleted = 0
		AND cmn_pro_product_supplier_regionalbindings.Tenant_RefID = @TenantID
	LEFT JOIN cmn_pro_product_suppliers ON cmn_pro_product_supplier_regionalbindings.ProductSupplier_RefID = cmn_pro_product_suppliers.CMN_PRO_Product_SupplierID
		AND cmn_pro_product_suppliers.CMN_PRO_Product_RefID = @ProductID
		AND cmn_pro_product_suppliers.SupplierPriority = 0
		AND cmn_pro_product_suppliers.IsDeleted = 0
		AND cmn_pro_product_suppliers.Tenant_RefID = @TenantID
	LEFT JOIN cmn_bpt_suppliers ON cmn_pro_product_suppliers.CMN_BPT_Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
		AND cmn_bpt_suppliers.IsDeleted = 0
		AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
	LEFT JOIN cmn_bpt_businessparticipants ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
		AND cmn_bpt_businessparticipants.IsDeleted = 0
		AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
	WHERE cmn_economicregion.IsDeleted = 0
		AND cmn_economicregion.Tenant_RefID = @TenantID
  