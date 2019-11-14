
Select
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Creation_Timestamp,
  cmn_pro_products.CMN_PRO_ProductID,
  hec_products.Recepie As ArticleRecipe,
  hec_products.HEC_ProductID   
From
  cmn_pro_products Inner Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID   And
  hec_products.IsDeleted = 0 And
  hec_products.Tenant_RefID = @TenantID
Where
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0 
  