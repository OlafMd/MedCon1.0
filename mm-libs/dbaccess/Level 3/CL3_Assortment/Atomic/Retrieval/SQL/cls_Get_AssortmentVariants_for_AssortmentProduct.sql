
	SELECT cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID
	FROM cmn_pro_ass_assortmentproducts
	INNER JOIN cmn_pro_products ON cmn_pro_products.CMN_PRO_ProductID = cmn_pro_ass_assortmentproducts.Ext_CMN_PRO_Product_RefID
		AND cmn_pro_products.IsDeleted = 0
		AND cmn_pro_products.Tenant_RefID = @TenantID
	INNER JOIN cmn_pro_product_variants ON cmn_pro_product_variants.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
		AND cmn_pro_product_variants.IsDeleted = 0
		AND cmn_pro_product_variants.Tenant_RefID = @TenantID
	INNER JOIN cmn_pro_ass_assortmentvariants ON cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID
		AND cmn_pro_ass_assortmentvariants.IsDeleted = 0
		AND cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID
	WHERE cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID = @AssortmentProductID
		AND cmn_pro_ass_assortmentproducts.Tenant_RefID = @TenantID
		AND cmn_pro_ass_assortmentproducts.IsDeleted = 0
  