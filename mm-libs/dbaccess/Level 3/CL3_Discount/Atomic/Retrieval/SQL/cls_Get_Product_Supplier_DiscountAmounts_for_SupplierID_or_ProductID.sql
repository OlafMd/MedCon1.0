
	SELECT
		cmn_pro_product_supplier_discountvalues.ORD_PRC_DiscountType_RefID,
		cmn_pro_product_supplier_discountvalues.DiscountValue,
		ord_prc_discounttypes.GlobalPropertyMatchingID AS DiscountType_GlobalPropertyMatchingID
	FROM
		cmn_pro_product_suppliers
	INNER JOIN cmn_pro_product_supplier_discountvalues
		ON cmn_pro_product_suppliers.CMN_PRO_Product_SupplierID = cmn_pro_product_supplier_discountvalues.Product_Supplier_RefID
		AND cmn_pro_product_supplier_discountvalues.IsDeleted = 0
		AND cmn_pro_product_supplier_discountvalues.Tenant_RefID = @TenantID
	INNER JOIN ord_prc_discounttypes
		ON ord_prc_discounttypes.ORD_PRC_DiscountTypeID = cmn_pro_product_supplier_discountvalues.ORD_PRC_DiscountType_RefID
		AND ord_prc_discounttypes.IsDeleted = 0
		AND ord_prc_discounttypes.Tenant_RefID = @TenantID
	WHERE
		cmn_pro_product_suppliers.IsDeleted = 0
		AND cmn_pro_product_suppliers.Tenant_RefID = @TenantID
		AND @ProductID IS NULL OR cmn_pro_product_suppliers.CMN_PRO_Product_RefID = @ProductID
		AND @SupplierID IS NULL OR cmn_pro_product_suppliers.CMN_BPT_Supplier_RefID = @SupplierID
	
  