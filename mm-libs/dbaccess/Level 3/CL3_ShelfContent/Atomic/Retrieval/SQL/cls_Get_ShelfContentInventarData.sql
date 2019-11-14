
	SELECT
	  LOG_WRH_Shelf_Contents.LOG_WRH_Shelf_ContentID,
    LOG_WRH_Shelf_Contents.Shelf_RefID,
	  CMN_PRO_Products.Product_Number,
	  CMN_PRO_Products.Product_Name_DictID,
	  CMN_PRO_Product_Variants.VariantName_DictID,
    CMN_Units.Label_DictID
	FROM
	  LOG_WRH_Shelf_Contents
    LEFT JOIN LOG_WRH_Shelves ON LOG_WRH_Shelf_Contents.Shelf_RefID = LOG_WRH_Shelves.LOG_WRH_ShelfID
    AND LOG_WRH_Shelves.IsDeleted = 0 
    AND LOG_WRH_Shelves.Tenant_RefID = @TenantID
    LEFT JOIN CMN_Units ON CMN_Units.CMN_UnitID = LOG_WRH_Shelves.ShelfCapacity_Unit_RefID
    AND CMN_Units.IsDeleted = 0 
    AND CMN_Units.Tenant_RefID = @TenantID
	  LEFT JOIN CMN_PRO_Products
	    ON LOG_WRH_Shelf_Contents.Product_RefID =
	         CMN_PRO_Products.CMN_PRO_ProductID AND
	       cmn_pro_products.Tenant_RefID = log_wrh_shelf_contents.Tenant_RefID AND
	       cmn_pro_products.IsDeleted = 0
	  LEFT JOIN CMN_PRO_Product_Variants
	    ON LOG_WRH_Shelf_Contents.Product_Variant_RefID =
	         cmn_pro_product_variants.CMN_PRO_Product_VariantID AND
	       CMN_PRO_Product_Variants.Tenant_RefID =
	         log_wrh_shelf_contents.Tenant_RefID AND
	       CMN_PRO_Product_Variants.IsDeleted = 0
	WHERE
	  LOG_WRH_Shelf_Contents.Shelf_RefID = @ShelfIDList AND
	  LOG_WRH_Shelf_Contents.Tenant_RefID = @TenantID AND
	  LOG_WRH_Shelf_Contents.IsDeleted = 0
  