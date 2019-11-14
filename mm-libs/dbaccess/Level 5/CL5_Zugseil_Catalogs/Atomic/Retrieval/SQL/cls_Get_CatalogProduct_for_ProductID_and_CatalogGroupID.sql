
	SELECT
	  CMN_PRO_Catalog_Products.CMN_PRO_Catalog_ProductID,
	  CMN_PRO_Catalog_Products.CMN_PRO_Product_RefID
	FROM
	  CMN_PRO_Catalog_Product_2_ProductGroup
	  INNER JOIN CMN_PRO_Catalog_Products
	    ON cmn_pro_catalog_products.CMN_PRO_Catalog_ProductID =
	         cmn_pro_catalog_product_2_productgroup.CMN_PRO_Catalog_Product_RefID AND
	       CMN_PRO_Catalog_Products.IsDeleted = 0 AND
	       CMN_PRO_Catalog_Products.Tenant_RefID = @TenantID AND
	       CMN_PRO_Catalog_Products.CMN_PRO_Product_RefID = @ProductID
	WHERE
	  CMN_PRO_Catalog_Product_2_ProductGroup.IsDeleted = 0 AND
	  CMN_PRO_Catalog_Product_2_ProductGroup.Tenant_RefID = @TenantID AND
	  CMN_PRO_Catalog_Product_2_ProductGroup.CMN_PRO_Catalog_ProductGroup_RefID =
	    @CatalogGroupID
  