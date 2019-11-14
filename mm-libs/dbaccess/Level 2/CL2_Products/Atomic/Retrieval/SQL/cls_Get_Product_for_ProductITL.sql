
	SELECT
	  *
	FROM
	  cmn_pro_products
	WHERE
	  Tenant_RefID = @TenantID AND
	  ProductITL = @ProductITL AND
	  IsDeleted = 0
  