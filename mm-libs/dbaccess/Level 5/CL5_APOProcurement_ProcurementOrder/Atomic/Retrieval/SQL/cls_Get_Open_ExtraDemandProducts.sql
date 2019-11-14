
	SELECT
		ord_prc_extrademandproducts.ORD_PRC_ExtraDemandProductID,
		ord_prc_extrademandproducts.Supplier_RefID,
		ord_prc_extrademandproducts.Product_RefID,
		ord_prc_extrademandproducts.CreatedFor_Office_RefID,
		ord_prc_extrademandproducts.CreatedBy_BusinessParticipant_RefID,
		ord_prc_extrademandproducts.ProcurementOrderPosition_RefID,
		ord_prc_extrademandproducts.RequestedQuantity,
		ord_prc_extrademandproducts.IsProcurementRunning,
		ord_prc_extrademandproducts.DeliveryTo_Warehouse_RefID,
		bp_suppliers.DisplayName as Supplier_Name
	FROM
		ord_prc_extrademandproducts
	LEFT OUTER JOIN cmn_bpt_suppliers
		ON cmn_bpt_suppliers.CMN_BPT_SupplierID = ord_prc_extrademandproducts.Supplier_RefID
		AND cmn_bpt_suppliers.IsDeleted = 0
		AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
	LEFT OUTER JOIN cmn_bpt_businessparticipants bp_suppliers
		ON bp_suppliers.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
		AND bp_suppliers.IsDeleted = 0
		AND bp_suppliers.Tenant_RefID = @TenantID
	WHERE
		ord_prc_extrademandproducts.IsDeleted = 0
		AND ord_prc_extrademandproducts.Tenant_RefID = @TenantID
		AND (ord_prc_extrademandproducts.ProcurementOrderPosition_RefID = 0x00000000000000000000000000000000 
				OR ord_prc_extrademandproducts.ProcurementOrderPosition_RefID IS NULL)

  