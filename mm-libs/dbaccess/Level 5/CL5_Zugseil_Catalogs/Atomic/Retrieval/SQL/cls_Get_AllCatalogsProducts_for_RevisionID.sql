
Select Distinct
  (cmn_pro_products.CMN_PRO_ProductID) As CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.ProductITL,
  cmn_pro_products.ProductAdditionalInfoXML,
  cmn_bpt_businessparticipants.DisplayName As Producer_DisplayName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  acc_tax_taxes.TaxRate,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel,
  cmn_units.ISOCode,
  cmn_sls_prices.PriceAmount
From
  cmn_pro_catalog_products Inner Join
  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
    cmn_pro_catalog_products.CMN_PRO_Product_RefID Inner Join
  cmn_pro_product_variants On cmn_pro_products.CMN_PRO_ProductID =
    cmn_pro_product_variants.CMN_PRO_Product_RefID And
    cmn_pro_product_variants.IsStandardProductVariant = 1 Left Join
  cmn_sls_prices On cmn_sls_prices.CMN_PRO_Product_Variant_RefID =
    cmn_pro_product_variants.CMN_PRO_Product_VariantID Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_pro_products.ProducingBusinessParticipant_RefID Left Join
  cmn_pro_product_salestaxassignmnets On cmn_pro_products.CMN_PRO_ProductID =
    cmn_pro_product_salestaxassignmnets.Product_RefID Left Join
  acc_tax_taxes On acc_tax_taxes.ACC_TAX_TaxeID =
    cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID =
    cmn_pro_products.PackageInfo_RefID Left Join
  cmn_units
    On cmn_units.CMN_UnitID =
    cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID
Where
  cmn_pro_catalog_products.CMN_PRO_Catalog_Revision_RefID = @RevisionID And
  cmn_pro_catalog_products.IsDeleted = 0 And
  cmn_pro_catalog_products.Tenant_RefID = @TenantID And
  cmn_pro_product_variants.IsStandardProductVariant = 1 And
  cmn_sls_prices.PricelistRelease_RefID = @PricelistReleaseID And
  cmn_sls_prices.CMN_Currency_RefID = @CurrencyID
  