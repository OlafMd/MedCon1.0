
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Product_DocumentationStructure_RefID
From
  cmn_pro_products cmn_pro_products
Where
  cmn_pro_products.CMN_PRO_ProductID = @ProductID And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0
