
          SELECT cmn_pro_products.CMN_PRO_ProductID,
                 cmn_pro_products.Product_Name_DictID,
                 cmn_pro_products_de.Content,
                 cmn_pro_products.Product_Description_DictID,
                 cmn_pro_products.IsDeleted,
                 cmn_pro_products.Product_Number,
                 cmn_pro_products.ProductType_RefID,
                 cmn_pro_products.IsProduct_Article,
                 cmn_pro_products.IsPlaceholderArticle
          FROM cmn_pro_products
          LEFT JOIN cmn_pro_products_de ON cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID
          AND cmn_pro_products_de.Language_RefID = @LanguageID
          AND cmn_pro_products_de.IsDeleted = 0
          WHERE cmn_pro_products.IsDeleted=0
            AND cmn_pro_products.IsProduct_Article = 1
            AND cmn_pro_products.Tenant_RefID = @TenantID
            AND (@SearchCriteria IS NULL
                 OR UPPER(cmn_pro_products_de.Content) LIKE @SearchCriteria
                 OR UPPER(cmn_pro_products.Product_Number) LIKE @SearchCriteria)
         ORDER BY cmn_pro_products_de.Content         
                 LIMIT @PageSize OFFSET @ActivePage
   