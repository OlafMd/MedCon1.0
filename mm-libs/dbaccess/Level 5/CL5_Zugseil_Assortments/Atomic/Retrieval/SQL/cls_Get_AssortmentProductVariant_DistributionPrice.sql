
Select
  cmn_price_values.PriceValue_Amount
From
  cmn_pro_product_variants Inner Join
  cmn_pro_ass_assortmentvariants
    On cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID =
    cmn_pro_product_variants.CMN_PRO_Product_VariantID And
    cmn_pro_ass_assortmentvariants.IsDeleted = 0 And
    cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID Left Join
  cmn_pro_ass_distributionprice_values
    On cmn_pro_ass_assortmentvariants.DistributionPrice_RefID =
    cmn_pro_ass_distributionprice_values.DistributionPrice_RefID And
    cmn_pro_ass_distributionprice_values.IsDeleted = 0 And
    cmn_pro_ass_distributionprice_values.Tenant_RefID = @TenantID And
    Now() Between cmn_pro_ass_distributionprice_values.ValidFrom And
    cmn_pro_ass_distributionprice_values.ValidThrough And
    cmn_pro_ass_distributionprice_values.IsDeleted = 0 And
    cmn_pro_ass_distributionprice_values.Tenant_RefID = @TenantID Left Join
  cmn_price_values On cmn_pro_ass_distributionprice_values.CMN_Price_RefID =
    cmn_price_values.Price_RefID And cmn_price_values.IsDeleted = 0 And
    cmn_price_values.Tenant_RefID = @TenantID
Where
  cmn_pro_product_variants.IsDeleted = 0 And
  cmn_pro_product_variants.Tenant_RefID = @TenantID And
  cmn_price_values.PriceValue_Currency_RefID = @CurrencyID And
  cmn_pro_product_variants.CMN_PRO_Product_VariantID = @ProductVariantID
  