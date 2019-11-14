Select
   cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_catalog_products.CMN_PRO_Catalog_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number
From
  cmn_pro_catalog_products Inner Join
  cmn_pro_catalog_product_2_productgroup
    On cmn_pro_catalog_product_2_productgroup.CMN_PRO_Catalog_Product_RefID =
    cmn_pro_catalog_products.CMN_PRO_Catalog_ProductID Inner Join
  cmn_pro_products On cmn_pro_catalog_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID
Where
  cmn_pro_catalog_product_2_productgroup.Tenant_RefID = @TenantID And
  cmn_pro_catalog_product_2_productgroup.IsDeleted = 0  And
  cmn_pro_catalog_product_2_productgroup.CMN_PRO_Catalog_ProductGroup_RefID =  @CatalogProductGroups And
  cmn_pro_catalog_products.Tenant_RefID = @TenantID And
  cmn_pro_catalog_products.IsDeleted = 0 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID 
  group by cmn_pro_products.CMN_PRO_ProductID
  ORDER BY cmn_pro_products.Product_Number
  LIMIT @PageSize OFFSET @ActivePage
   