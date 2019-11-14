
Select
  cmn_pro_product_variants.CMN_PRO_Product_VariantID,
  cmn_pro_product_variants.IsStandardProductVariant,
  cmn_price_values.PriceValue_Amount
From
  cmn_pro_product_variants Left Join
  cmn_pro_ass_assortmentvariants
    On cmn_pro_product_variants.CMN_PRO_Product_VariantID =
    cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID And
    cmn_pro_ass_assortmentvariants.IsDeleted = 0 And
    cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID Left Join
  cmn_pro_ass_distributionprice_values
    On cmn_pro_ass_assortmentvariants.DistributionPrice_RefID =
    cmn_pro_ass_distributionprice_values.DistributionPrice_RefID And
    cmn_pro_ass_assortmentvariants.IsDeleted = 0 And
    cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID And
    (Now() Between cmn_pro_ass_distributionprice_values.ValidFrom And
    cmn_pro_ass_distributionprice_values.ValidThrough) Left Join
  cmn_price_values On cmn_pro_ass_distributionprice_values.CMN_Price_RefID =
    cmn_price_values.Price_RefID And cmn_price_values.IsDeleted = 0 And
    cmn_price_values.Tenant_RefID = @TenantID And
    cmn_price_values.PriceValue_Currency_RefID = @CurrencyID
Where
  cmn_pro_product_variants.IsDeleted = 0 And
  cmn_pro_product_variants.Tenant_RefID = @TenantID And
  cmn_pro_product_variants.CMN_PRO_Product_RefID = @ProductID    
  