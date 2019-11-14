
	SELECT
	  CMN_PRO_Product_VariantID
	FROM
	  CMN_PRO_Product_Variants
	WHERE
	  IsDeleted = 0 AND
	  IsStandardProductVariant = 1 AND
	  Tenant_RefID = @TenantID AND
	  CMN_PRO_Product_RefID = @ProductID
  