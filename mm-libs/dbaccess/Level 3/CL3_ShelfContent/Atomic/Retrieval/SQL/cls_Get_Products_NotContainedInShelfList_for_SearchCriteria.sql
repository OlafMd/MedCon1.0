
	SELECT
	  CMN_PRO_Products.Product_Number,
	  CMN_PRO_Products.CMN_PRO_ProductID,
	  CMN_PRO_Products.Product_Name_DictID
	FROM CMN_PRO_Products 
	  LEFT JOIN cmn_pro_products_de
	    ON CMN_PRO_Products.Product_Name_DictID = cmn_pro_products_de.DictID AND
	       cmn_pro_products_de.Language_RefID = @LanguageID AND
	       cmn_pro_products_de.IsDeleted = 0 
	WHERE
  (@SearchCriteria IS NULL OR
	        (Upper( cmn_pro_products_de.Content) LIKE
	          CONCAT(
	            Upper(@SearchCriteria),
	            '%') OR
	        Upper( CMN_PRO_Products.Product_Number) LIKE
	          CONCAT(
	            Upper( @SearchCriteria),
	            '%'))) AND
	  CMN_PRO_Products.IsDeleted = 0 AND
	  CMN_PRO_Products.Tenant_RefID = @TenantID AND
	  (SELECT
	     COUNT( LOG_WRH_Shelf_Contents.LOG_WRH_Shelf_ContentID) AS numberOfItems
	   FROM
	     LOG_WRH_Shelf_Contents
	   WHERE
	     LOG_WRH_Shelf_Contents.IsDeleted = 0 AND
	     LOG_WRH_Shelf_Contents.Tenant_RefID = @TenantID AND
	     LOG_WRH_Shelf_Contents.Shelf_RefID = @ShelfIDs AND
	     LOG_WRH_Shelf_Contents.Product_RefID = CMN_PRO_Products.CMN_PRO_ProductID AND 
       LOG_WRH_Shelf_Contents.Quantity_Current > 0
	  ) < @NumberOfShelves
    GROUP BY CMN_PRO_Products.CMN_PRO_ProductID
  