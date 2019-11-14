
	SELECT
	  CMN_PRO_Dimension_Values.DimensionValue_Text_DictID,
	  CMN_PRO_Dimensions.DimensionName_DictID
	FROM
	  cmn_pro_variant_dimensionvalues
	  INNER JOIN cmn_pro_dimension_values
	    ON cmn_pro_dimension_values.CMN_PRO_Dimension_ValueID =
	         cmn_pro_variant_dimensionvalues.DimensionValue_RefID AND
	       cmn_pro_dimension_values.IsDeleted = 0 AND
	       cmn_pro_dimension_values.Tenant_RefID = @TenantID
	  INNER JOIN cmn_pro_dimensions
	    ON cmn_pro_dimensions.CMN_PRO_DimensionID =
	         cmn_pro_dimension_values.Dimensions_RefID AND
	       cmn_pro_dimensions.IsDeleted = 0 AND
	       cmn_pro_dimensions.Tenant_RefID = @TenantID
	WHERE
	  cmn_pro_variant_dimensionvalues.IsDeleted = 0 AND
	  cmn_pro_variant_dimensionvalues.Tenant_RefID = @TenantID AND
	  cmn_pro_variant_dimensionvalues.ProductVariant_RefID = @ProductVariantID
  