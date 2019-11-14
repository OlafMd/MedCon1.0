
	SELECT
	  CMN_PRO_Product_Variants.CMN_PRO_Product_VariantID,
	  CMN_PRO_Product_Variants.ProductVariantITL,
	  CMN_PRO_Product_Variants.VariantName_DictID,
    CMN_PRO_Product_Variants.IsStandardProductVariant
	FROM
	  CMN_PRO_Catalog_Products
	  INNER JOIN CMN_PRO_Product_Variants
	    ON cmn_pro_product_variants.CMN_PRO_Product_VariantID =
	         cmn_pro_catalog_products.CMN_PRO_Product_Variant_RefID AND
	       CMN_PRO_Product_Variants.IsDeleted = 0 AND
	       cmn_pro_product_variants.Tenant_RefID = @TenantID
	WHERE
	  CMN_PRO_Catalog_Products.IsDeleted = 0 AND
	  CMN_PRO_Catalog_Products.CMN_PRO_Product_RefID = @ProductID AND
	  CMN_PRO_Catalog_Products.Tenant_RefID = @TenantID
    GROUP BY CMN_PRO_Product_Variants.CMN_PRO_Product_VariantID
  