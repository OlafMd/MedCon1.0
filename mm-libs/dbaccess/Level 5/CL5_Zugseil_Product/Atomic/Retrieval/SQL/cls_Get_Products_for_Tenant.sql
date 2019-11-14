
      
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products_de.Content,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.IsPlaceholderArticle
From
  cmn_pro_products Left Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID And cmn_pro_products_de.Language_RefID =
    @LanguageID And cmn_pro_products_de.IsDeleted = 0
Where
  cmn_pro_products.CMN_PRO_ProductID NOT = @ExcludedProducts And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  (@SearchCriteria Is Null Or
    Upper(cmn_pro_products_de.Content) Like CONCAT('%',Upper(@SearchCriteria),'%') Or
    Upper(cmn_pro_products.Product_Number) Like CONCAT('%',Upper(@SearchCriteria),'%')) And
  cmn_pro_products.IsProductForInternalDistributionOnly = 0 And
  cmn_pro_products.IsProductHiddenFromDisplay = 0
Order By
  cmn_pro_products_de.Content  
LIMIT @PageSize OFFSET @ActivePage
	                 
  