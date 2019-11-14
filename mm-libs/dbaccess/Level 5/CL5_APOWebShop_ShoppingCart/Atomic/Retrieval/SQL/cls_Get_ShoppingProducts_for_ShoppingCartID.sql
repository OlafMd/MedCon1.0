
Select
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_shoppingcart.IsProcurementOrderCreated,
  ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID As ShoppingCartStatus,
  ord_prc_office_shoppingcarts.ORD_PRC_Office_ShoppingCartID,
  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID,
  cmn_str_offices.Office_InternalName,
  shoppingcart_products.Group_GlobalPropertyMatchingID,
  shoppingcart_products.Price,
  shoppingcart_products.CurrencyISO,
  shoppingcart_products.CurrencySymbol,
  shoppingcart_products.TaxRate,
  shoppingcart_products.Product_Name_DictID,
  shoppingcart_products.Product_Number,
  shoppingcart_products.SubscribedCatalog_PricelistRelease_RefID,
  shoppingcart_products.ORD_PRC_ShoppingCart_ProductID,
  shoppingcart_products.CMN_PRO_Product_RefID,
  shoppingcart_products.CMN_PRO_Product_Variant_RefID,
  shoppingcart_products.CMN_PRO_Product_Release_RefID,
  shoppingcart_products.SequenceNumber,
  shoppingcart_products.Quantity,
  shoppingcart_products.IsCanceled as IsProductCanceled,
  shoppingcart_products.IsDeleted as IsProductDeleted,
  shoppingcart_products.Comment,
  shoppingcart_products.IsProductReplacementAllowed
From
  ord_prc_shoppingcart Inner Join
  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID And
    ord_prc_office_shoppingcarts.IsDeleted = 0 Inner Join
  cmn_str_offices On ord_prc_office_shoppingcarts.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0 Left Join
  (Select
    cmn_pro_productgroups.GlobalPropertyMatchingID As
    Group_GlobalPropertyMatchingID,
    cmn_sls_prices.PriceAmount As Price,
    cmn_currencies.ISO4127 As CurrencyISO,
    cmn_currencies.Symbol As CurrencySymbol,
    acc_tax_taxes.TaxRate,
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.Product_Number,
    cmn_pro_subscribedcatalogs.SubscribedCatalog_PricelistRelease_RefID,
    ord_prc_shoppingcart_products.*,
    cmn_pro_products.CMN_PRO_ProductID
  From
    cmn_pro_product_2_productgroup Left Join
    cmn_pro_productgroups
      On cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID =
      cmn_pro_productgroups.CMN_PRO_ProductGroupID And
      cmn_pro_productgroups.IsDeleted = 0 Left Join
    cmn_sls_prices On cmn_sls_prices.IsDeleted = 0 Left Join
    cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
      cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 Left Join
    cmn_pro_product_salestaxassignmnets
      On cmn_pro_product_salestaxassignmnets.IsDeleted = 0 Left Join
    acc_tax_taxes
      On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID =
      acc_tax_taxes.ACC_TAX_TaxeID And acc_tax_taxes.IsDeleted = 0 Inner Join
    cmn_pro_subscribedcatalogs
      On cmn_pro_subscribedcatalogs.SubscribedCatalog_PricelistRelease_RefID =
      cmn_sls_prices.PricelistRelease_RefID Right Join
    cmn_pro_products On cmn_pro_product_salestaxassignmnets.Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.CMN_PRO_ProductID
      = cmn_sls_prices.CMN_PRO_Product_RefID And
      cmn_pro_products.CMN_PRO_ProductID =
      cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID Left Join
    ord_prc_shoppingcart_products On cmn_pro_products.CMN_PRO_ProductID =
      ord_prc_shoppingcart_products.CMN_PRO_Product_RefID And
      cmn_pro_products.IsDeleted = 0
  Where
    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID = @ShoppingCartID
    And
    cmn_pro_products.Tenant_RefID = @TenantID And
    cmn_sls_prices.Tenant_RefID = @TenantID) shoppingcart_products
    On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    shoppingcart_products.ORD_PRC_ShoppingCart_RefID And
    shoppingcart_products.IsDeleted = 0 And shoppingcart_products.IsCanceled = 0
  Left Join
  ord_prc_shoppingcart_statuses
    On ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID =
    ord_prc_shoppingcart_statuses.ORD_PRC_ShoppingCart_StatusID And
    ord_prc_shoppingcart_statuses.IsDeleted = 0
Where
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID = @ShoppingCartID And
  ord_prc_shoppingcart.IsDeleted = 0 And
  ord_prc_shoppingcart.Tenant_RefID = @TenantID
  