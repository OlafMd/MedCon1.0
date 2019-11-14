
	SELECT 
		cmn_pro_products.CMN_PRO_ProductID,
		cmn_pro_products.IsStorage_BatchNumberMandatory,
		cmn_pro_products.IsStorage_ExpiryDateMandatory,
		SUM(log_wrh_shelf_contents.Quantity_Current) AS StockQuantity
	FROM
		cmn_pro_products
		LEFT OUTER JOIN log_wrh_shelf_contents ON log_wrh_shelf_contents.Product_RefID = cmn_pro_products.CMN_PRO_ProductID
		AND log_wrh_shelf_contents.Tenant_RefID = @TenantID
	WHERE
		cmn_pro_products.IsDeleted = 0
		AND cmn_pro_products.Tenant_RefID = @TenantID
		AND cmn_pro_products.CMN_PRO_ProductID = @ArticleList
	GROUP BY cmn_pro_products.CMN_PRO_ProductID
	
  