
    SELECT count(cmn_pro_products.CMN_PRO_ProductID) as NumberOfProducts
    FROM cmn_pro_products
    WHERE cmn_pro_products.IsDeleted = 0
      AND cmn_pro_products.Tenant_RefID = @TenantID
      AND cmn_pro_products.Product_Number=@ProductNumber
      AND (@ProductID is null or cmn_pro_products.CMN_PRO_ProductID!=@ProductID)
  