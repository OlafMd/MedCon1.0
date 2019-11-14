
    Select
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_shoppingcart.IsProcurementOrderCreated,
  ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID As ShoppingCartStatus,
  ord_prc_office_shoppingcarts.ORD_PRC_Office_ShoppingCartID,
  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID,
  cmn_str_offices.Office_InternalName,
  shopping_product.ORD_PRC_ShoppingCart_ProductID,
  shopping_product.CMN_PRO_Product_RefID,
  shopping_product.CMN_PRO_Product_Variant_RefID,
  shopping_product.CMN_PRO_Product_Release_RefID,
  shopping_product.Quantity,
  shopping_product.IsCanceled As IsProductCanceled,
  shopping_product.IsDeleted As IsProductDeleted,
  shopping_product.IsProductReplacementAllowed As IsProductReplacementAllowed,
  shopping_product.Comment,
  shopping_product.Product_Name_DictID,
  shopping_product.Product_Number,
  shopping_product.ProductITL,
  shopping_product.GlobalPropertyMatchingID As Group_GlobalPropertyMatchingID,
  shopping_product.PriceAmount As Price,
  shopping_product.ISO4127 As CurrencyISO,
  shopping_product.Symbol As CurrencySymbol,
  shopping_product.TaxRate
From
  ord_prc_shoppingcart Inner Join
  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID And
    ord_prc_office_shoppingcarts.IsDeleted = 0 Inner Join
  cmn_str_offices On ord_prc_office_shoppingcarts.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0 Left Join
  ord_prc_shoppingcart_statuses
    On ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID =
    ord_prc_shoppingcart_statuses.ORD_PRC_ShoppingCart_StatusID And
    ord_prc_shoppingcart_statuses.IsDeleted = 0 Left Join
  (Select
    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID,
    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID,
    ord_prc_shoppingcart_products.CMN_PRO_Product_RefID,
    ord_prc_shoppingcart_products.CMN_PRO_Product_Variant_RefID,
    ord_prc_shoppingcart_products.CMN_PRO_Product_Release_RefID,
    ord_prc_shoppingcart_products.Quantity,
    ord_prc_shoppingcart_products.IsCanceled,
    ord_prc_shoppingcart_products.IsDeleted,
    ord_prc_shoppingcart_products.Comment,
    ord_prc_shoppingcart_products.IsProductReplacementAllowed,
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.Product_Number,
    cmn_pro_products.ProductITL,
    cmn_pro_productgroups.GlobalPropertyMatchingID,
    cmn_sls_prices.PriceAmount,
    cmn_currencies.ISO4127,
    cmn_currencies.Symbol,
    acc_tax_taxes.TaxRate
  From
    ord_prc_shoppingcart_products Inner Join
    cmn_pro_products On ord_prc_shoppingcart_products.CMN_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0 And
      cmn_pro_products.IsProduct_Article = 1 And
      cmn_pro_products.IsProductAvailableForOrdering = 1 Inner Join
    cmn_pro_product_2_productgroup
      On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID And
      cmn_pro_product_2_productgroup.IsDeleted = 0 Inner Join
    cmn_pro_productgroups
      On cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID =
      cmn_pro_productgroups.CMN_PRO_ProductGroupID And
      cmn_pro_productgroups.IsDeleted = 0 Left Join
    cmn_sls_prices On cmn_sls_prices.CMN_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID And cmn_sls_prices.IsDeleted = 0
    Left Join
    cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
      cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 Left Join
    cmn_pro_product_salestaxassignmnets On cmn_pro_products.CMN_PRO_ProductID =
      cmn_pro_product_salestaxassignmnets.Product_RefID And
      cmn_pro_product_salestaxassignmnets.IsDeleted = 0 Left Join
    acc_tax_taxes
      On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID =
      acc_tax_taxes.ACC_TAX_TaxeID And acc_tax_taxes.IsDeleted = 0 Inner Join
    cmn_pro_subscribedcatalogs
      On cmn_pro_subscribedcatalogs.SubscribedCatalog_PricelistRelease_RefID =
      cmn_sls_prices.PricelistRelease_RefID
  Where
    ord_prc_shoppingcart_products.IsCanceled = 0 And
    ord_prc_shoppingcart_products.IsDeleted = 0) shopping_product
    On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    shopping_product.ORD_PRC_ShoppingCart_RefID
Where
  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID = @OfficeID And
  ord_prc_shoppingcart.IsDeleted = 0 And
  ord_prc_shoppingcart.Tenant_RefID = @TenantID And
  ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID = @ShoppingCartStatusID
  