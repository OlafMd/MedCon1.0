
	Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  hec_product_dosageforms.HEC_Product_DosageFormID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_units.CMN_UnitID,
  cmn_units.Label_DictID,
  cmn_units.ISOCode,
  cmn_pro_pac_packageinfo.PackageContent_Amount
From
  cmn_pro_products Inner Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID And hec_products.IsDeleted = 0 Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID And
    hec_product_dosageforms.IsDeleted = 0 Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
    cmn_pro_pac_packageinfo.IsDeleted = 0 Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID And cmn_units.IsDeleted = 0 Inner Join
  cmn_pro_product_2_productgroup
    On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  cmn_pro_productgroups
    On cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID =
    cmn_pro_productgroups.CMN_PRO_ProductGroupID
Where
  cmn_pro_productgroups.GlobalPropertyMatchingID = @ProductGroupMatchingID And
  cmn_pro_products.IsProductAvailableForOrdering = 1 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.IsProduct_Article = 1 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_product_2_productgroup.IsDeleted = 0 And
  cmn_pro_productgroups.IsDeleted = 0
  