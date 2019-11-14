
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  hec_product_dosageforms.HEC_Product_DosageFormID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_units.CMN_UnitID,
  cmn_units.Label_DictID,
  cmn_pro_productgroups.GlobalPropertyMatchingID,
  cmn_pro_products.IsProductAvailableForOrdering,
  cmn_sls_prices.PriceAmount As Price,
  cmn_currencies.ISO4127 As CurrencyISO,
  ord_prc_shoppingcart_products.Quantity
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
    cmn_pro_productgroups.CMN_PRO_ProductGroupID Inner Join
  cmn_sls_prices On cmn_sls_prices.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
    cmn_currencies.CMN_CurrencyID Left Join
  ord_prc_shoppingcart_products
    On ord_prc_shoppingcart_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And
    ord_prc_shoppingcart_products.IsDeleted = 0 Inner Join
  ord_prc_shoppingcart
    On ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID =
    ord_prc_shoppingcart.ORD_PRC_ShoppingCartID
Where
  cmn_pro_productgroups.GlobalPropertyMatchingID = @ProductGroupMatchingID And
  cmn_pro_products.IsProductAvailableForOrdering = 1 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.IsProduct_Article = 1 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_product_2_productgroup.IsDeleted = 0 And
  cmn_pro_productgroups.IsDeleted = 0 And
  ord_prc_shoppingcart.IsProcurementOrderCreated = 1 And
  ord_prc_shoppingcart.Creation_Timestamp > Date_Add(CurDate(), Interval
  -@NumberOfLastDays Day)
  