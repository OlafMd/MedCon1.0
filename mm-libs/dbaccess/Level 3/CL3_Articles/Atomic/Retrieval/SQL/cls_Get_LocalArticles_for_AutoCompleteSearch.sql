
  SELECT cmn_pro_products.CMN_PRO_ProductID,
         cmn_pro_products.ProductITL,
         cmn_pro_products_de.Content AS ProductName,
         cmn_pro_products.Product_Number
  FROM cmn_pro_products
  LEFT JOIN cmn_pro_products_de ON cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID
  AND cmn_pro_products_de.IsDeleted = 0
  WHERE cmn_pro_products.Tenant_RefID = @TenantID
    AND cmn_pro_products.IsDeleted = 0
    AND cmn_pro_products.IsProduct_Article = 1
    AND cmn_pro_products.IsProductAvailableForOrdering = IfNull(@IsAvailableForOrdering, cmn_pro_products.IsProductAvailableForOrdering)
    AND (@SearchCondition IS NULL
         OR (@SearchCondition IS NOT NULL
             AND (Upper(cmn_pro_products_de.Content) LIKE Upper(@SearchCondition)
                  OR (Upper(cmn_pro_products.Product_Number) LIKE Upper(@SearchCondition)))))
    AND cmn_pro_products_de.Language_RefID = @LanguageID
    AND cmn_pro_products.IfImportedFromExternalCatalog_CatalogSubscription_RefID = 0x00000000000000000000000000000000
  