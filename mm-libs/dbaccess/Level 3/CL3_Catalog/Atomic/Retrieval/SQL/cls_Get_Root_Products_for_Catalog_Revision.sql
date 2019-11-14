
Select
  cmn_pro_catalog_products.CMN_PRO_Catalog_ProductID,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_catalog_products.CMN_PRO_Catalog_Revision_RefID,
  cmn_pro_products.Product_Number,
  cmn_units.Label_DictID,
  cmn_units.Abbreviation_DictID,
  cmn_units.ISOCode,
  hec_product_dosageforms.DosageForm_Name_DictID,
  hec_product_dosageforms.DosageForm_Description_DictID,
  hec_product_dosageforms.GlobalPropertyMatchingID
From
  cmn_pro_catalog_products Inner Join
  cmn_pro_products On cmn_pro_catalog_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID Inner Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID
Where
  cmn_pro_catalog_products.CMN_PRO_Catalog_ProductID Not In (Select
    cmn_pro_catalog_product_2_productgroup.CMN_PRO_Catalog_Product_RefID
  From
    cmn_pro_catalog_product_2_productgroup
  Where
    cmn_pro_catalog_product_2_productgroup.Tenant_RefID = @TenantID And
    cmn_pro_catalog_product_2_productgroup.IsDeleted = 0) And
  cmn_pro_catalog_products.CMN_PRO_Catalog_Revision_RefID = @CatalogRevisionID
  And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_catalog_products.IsDeleted = 0 And
  cmn_pro_catalog_products.Tenant_RefID = @TenantID
  