
	SELECT CMN_PRO_ProductID, ProductITL
	FROM cmn_pro_products
	WHERE ProductITL = @ProductITLList
		AND IsDeleted = 0
		AND Tenant_RefID = @TenantID
  