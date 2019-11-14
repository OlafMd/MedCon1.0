Select
  cmn_pro_product_variants.CMN_PRO_Product_VariantID,
  cmn_pro_product_variants.IsStandardProductVariant,
  cmn_pro_product_variants.ProductVariantITL,
  cmn_pro_product_variants.IsImportedFromExternalCatalog,
  cmn_pro_product_variants.IsProductAvailableForOrdering,
  cmn_pro_product_variants.IsObsolete,
  cmn_pro_product_variants.VariantName_DictID,
  cmn_pro_dimension_values.CMN_PRO_Dimension_ValueID,
  cmn_pro_dimension_values.DimensionValue_Text_DictID,
  cmn_pro_dimension_values.OrderSequence As DimensionValue_OrderSequence,
  cmn_pro_dimensions.CMN_PRO_DimensionID,
  cmn_pro_dimensions.Abbreviation,
  cmn_pro_dimensions.DimensionName_DictID,
  cmn_pro_dimensions.OrderSequence As Dimension_OrderSequence,
  cmn_pro_dimensions.IsDimensionTemplate
From
  cmn_pro_product_variants Left Join
  cmn_pro_variant_dimensionvalues
    On cmn_pro_product_variants.CMN_PRO_Product_VariantID =
    cmn_pro_variant_dimensionvalues.ProductVariant_RefID And
    cmn_pro_variant_dimensionvalues.IsDeleted = 0 And
    cmn_pro_variant_dimensionvalues.Tenant_RefID = @TenantID Left Join
  cmn_pro_dimension_values
    On cmn_pro_variant_dimensionvalues.DimensionValue_RefID =
    cmn_pro_dimension_values.CMN_PRO_Dimension_ValueID And
    cmn_pro_dimension_values.IsDeleted = 0 And
    cmn_pro_dimension_values.Tenant_RefID = @TenantID Left Join
  cmn_pro_dimensions On cmn_pro_dimension_values.Dimensions_RefID =
    cmn_pro_dimensions.CMN_PRO_DimensionID And cmn_pro_dimensions.IsDeleted = 0
    And cmn_pro_dimensions.Tenant_RefID = @TenantID
Where
  cmn_pro_product_variants.CMN_PRO_Product_RefID = @ProductID And
  cmn_pro_product_variants.IsDeleted = 0 And
  cmn_pro_product_variants.Tenant_RefID = @TenantID