
Select
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Tenant_RefID,
  cmn_pro_products.Creation_Timestamp,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.CMN_PRO_ProductID
From
  cmn_pro_products
Where
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0
  