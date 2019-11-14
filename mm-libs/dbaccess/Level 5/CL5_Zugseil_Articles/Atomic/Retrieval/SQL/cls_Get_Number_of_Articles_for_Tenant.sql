
    Select
     Count(cmn_pro_products.CMN_PRO_ProductID) as NumberOfProducts
      From
        cmn_pro_products Left Join
        cmn_pro_products_de On cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID 
        And cmn_pro_products_de.Language_RefID =  @LanguageID And cmn_pro_products_de.IsDeleted = 0
    Where
      cmn_pro_products.IsDeleted = 0 And
      cmn_pro_products.Tenant_RefID = @TenantID
     AND (@SearchCriteria IS NULL OR UPPER(cmn_pro_products_de.Content) LIKE @SearchCriteria
                     OR UPPER(cmn_pro_products.Product_Number) LIKE @SearchCriteria)
  
  