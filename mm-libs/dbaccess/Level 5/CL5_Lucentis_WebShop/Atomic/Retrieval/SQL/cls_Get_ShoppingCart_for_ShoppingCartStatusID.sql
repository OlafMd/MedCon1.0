Select
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_shoppingcart.Creation_Timestamp As ShoppingCart_CreationDate,
  ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID,
  ord_prc_shoppingcart_products.CMN_PRO_Product_RefID,
  ord_prc_shoppingcart_products.Quantity,
  ord_prc_shoppingcart_products.IsCanceled As IsProductCanceled,
  ord_prc_shoppingcart_products.IsDeleted As IsProductDeleted,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.IsDeleted,
  acc_tax_taxes.TaxRate,
  cmn_sls_prices.PriceAmount
From
  ord_prc_shoppingcart  Left Join
  ord_prc_shoppingcart_products On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID And
    ord_prc_shoppingcart_products.IsDeleted = 0 And
    ord_prc_shoppingcart_products.IsCanceled = 0 Left Join
  cmn_pro_products On ord_prc_shoppingcart_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0
  Left Join
  cmn_pro_product_salestaxassignmnets On cmn_pro_products.CMN_PRO_ProductID =
    cmn_pro_product_salestaxassignmnets.Product_RefID And
    cmn_pro_product_salestaxassignmnets.IsDeleted = 0 Left Join
  acc_tax_taxes On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
    = acc_tax_taxes.ACC_TAX_TaxeID And acc_tax_taxes.IsDeleted = 0 left Join
  cmn_sls_prices On cmn_pro_products.CMN_PRO_ProductID =
    cmn_sls_prices.CMN_PRO_Product_RefID left Join
  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID left Join
  cmn_str_offices On cmn_str_offices.CMN_STR_OfficeID =
    ord_prc_office_shoppingcarts.CMN_STR_Office_RefID And    
  (ord_prc_shoppingcart.IsDeleted = 0 Or
    ord_prc_shoppingcart.IsDeleted Is Null) And
  (cmn_sls_prices.IsDeleted = 0 Or
    cmn_sls_prices.IsDeleted Is Null) And
  ord_prc_office_shoppingcarts.IsDeleted = 0 And
  cmn_str_offices.IsDeleted = 0
Where
   
  ord_prc_shoppingcart.Tenant_RefID = @TenantID  And 
  ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID = @ShoppingCartStatusID and
  cmn_str_offices.Office_InternalName = @PracticeBPID