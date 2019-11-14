
Select
  cmn_pro_products.CMN_PRO_ProductID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_pro_products.PackageInfo_RefID,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel,
  cmn_units.Label_DictID,
  cmn_pro_products_de.Language_RefID,
  cmn_pro_products_de.Content As ProductName,
  cmn_pro_products.Product_Number,
  hec_product_dosageforms.GlobalPropertyMatchingID,
  cmn_units.ISOCode
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Inner Join
  cmn_units
    On cmn_units.CMN_UnitID =
    cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID Left Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID
Where
  cmn_pro_products.IsDeleted = 0 And
  hec_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsProduct_Article = 1 And
  hec_product_dosageforms.IsDeleted = 0 And
  cmn_pro_pac_packageinfo.IsDeleted = 0 And
  cmn_units.IsDeleted = 0 And
  cmn_pro_products.IsPlaceholderArticle = 1 And
  (cmn_pro_products_de.IsDeleted = 0 Or
    cmn_pro_products_de.IsDeleted Is Not Null) And
  Upper(cmn_pro_products_de.Content) Like Upper(@GeneralQuery) And
  Upper(cmn_units.ISOCode) Like Upper(@UnitQuery) And
  Upper(cmn_pro_products.Product_Number) Like Upper(@PznQuery)
  