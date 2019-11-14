
	SELECT
	  ProductVariantITL,
	  CMN_PRO_Product_VariantID
	FROM
	  CMN_PRO_Product_Variants
	WHERE
	  ProductVariantITL = @VariantITLList AND
	  IsDeleted = 0 AND
	  Tenant_RefID = @TenantID
  