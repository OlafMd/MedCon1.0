
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  hec_products.HEC_ProductID,
  hec_products.Recepie
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID
Where
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  hec_products.IsDeleted = 0
  