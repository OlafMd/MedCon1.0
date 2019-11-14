
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products_de.Content As ProductName,
  cmn_pro_products.Product_Number,
  hec_products.ProductDistributionStatus,
  hec_product_dosageforms.HEC_Product_DosageFormID,
  hec_product_dosageforms.GlobalPropertyMatchingID As
  DosageForm_GlobalPropertyMatchingID,
  cmn_pro_pac_packageinfo.PackageContent_Amount As UnitAmount,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel AS UnitAmount_DisplayLabel , 
  cmn_units.ISOCode As UnitIsoCode,
  cmn_pro_productgroups.GlobalPropertyMatchingID As
  Group_GlobalPropertyMatchingID,
  cmn_pro_products.IsProductAvailableForOrdering,
  cmn_sls_prices.PriceAmount As Price,
  cmn_currencies.ISO4127 As CurrencyISO,
  cmn_currencies.Symbol As CurrencySymbol,
  Sum(ord_prc_shoppingcart_products.Quantity) As Quantity,
  hec_pro_components.HEC_PRO_ComponentID,
  hec_pro_components.Component_Name_DictID,
  hec_pro_components.Component_SimpleName,
  hec_sub_substances.HEC_SUB_SubstanceID,
  hec_sub_substances.IsActiveComponent,
  hec_sub_substances.GlobalPropertyMatchingID As SubstanceName
From
  cmn_pro_products Inner Join
  cmn_pro_products_de On cmn_pro_products_de.DictID =
    cmn_pro_products.Product_Name_DictID Inner Join
  hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID And hec_products.IsDeleted = 0 Left Join
  hec_pro_product_components On hec_products.HEC_ProductID =
    hec_pro_product_components.HEC_PRO_Product_RefID And
    hec_pro_product_components.IsDeleted = 0 Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID And
    hec_product_dosageforms.IsDeleted = 0 Left Join
  hec_pro_components On hec_pro_product_components.HEC_PRO_Component_RefID =
    hec_pro_components.HEC_PRO_ComponentID And hec_pro_components.IsDeleted = 0
  Left Join
  hec_pro_component_substanceingredients
    On hec_pro_components.HEC_PRO_ComponentID =
    hec_pro_component_substanceingredients.Component_RefID And
    hec_pro_component_substanceingredients.IsDeleted = 0 Left Join
  hec_sub_substances On hec_pro_component_substanceingredients.Substance_RefID =
    hec_sub_substances.HEC_SUB_SubstanceID And hec_sub_substances.IsDeleted = 0
  Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
    cmn_pro_pac_packageinfo.IsDeleted = 0 Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID And cmn_units.IsDeleted = 0 Inner Join
  cmn_pro_product_2_productgroup
    On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And
    cmn_pro_product_2_productgroup.IsDeleted = 0 Inner Join
  cmn_pro_productgroups
    On cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID =
    cmn_pro_productgroups.CMN_PRO_ProductGroupID And
    cmn_pro_productgroups.IsDeleted = 0 Inner Join
  cmn_sls_prices On cmn_sls_prices.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_sls_prices.IsDeleted = 0
  Inner Join
  cmn_currencies On cmn_sls_prices.CMN_Currency_RefID =
    cmn_currencies.CMN_CurrencyID And cmn_currencies.IsDeleted = 0 Inner Join
  ord_prc_shoppingcart_products On cmn_pro_products.CMN_PRO_ProductID =
    ord_prc_shoppingcart_products.CMN_PRO_Product_RefID And
    ord_prc_shoppingcart_products.IsDeleted = 0 And
    ord_prc_shoppingcart_products.IsCanceled = 0 Inner Join
  ord_prc_shoppingcart
    On ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID =
    ord_prc_shoppingcart.ORD_PRC_ShoppingCartID And
    ord_prc_shoppingcart.IsDeleted = 0 Inner Join
  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID And
    ord_prc_office_shoppingcarts.IsDeleted = 0
Where
  cmn_pro_products.IsProductAvailableForOrdering = 1 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.IsProduct_Article = 1 And
  cmn_pro_productgroups.GlobalPropertyMatchingID = @ProductGroupMatchingID_List
  And
  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID = IfNull(@OfficeID,
  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID) And
  cmn_pro_products.Tenant_RefID = @TenantID And
  ord_prc_shoppingcart_products.Creation_Timestamp > Date_Add(CurDate(),
  Interval -@NumberOfLastDays Day) And
  cmn_pro_products_de.Language_RefID = @LanguageID And
  (@ProductNameStartWith Is Null Or
    (@ProductNameStartWith Is Not Null And
      Lower(cmn_pro_products_de.Content) Like
      Concat(Lower(@ProductNameStartWith), '%'))) And
  (@ProductNameContains Is Null Or
    (@ProductNameContains Is Not Null And
      (Lower(cmn_pro_products_de.Content) Like Concat('%',
        Lower(@ProductNameContains), '%') Or
        Lower(cmn_pro_products.Product_Number) Like Concat('%',
        Lower(@ProductNameContains), '%')))) And
  (@ProductNumberContains Is Null Or
    (@ProductNumberContains Is Not Null And
      Lower(cmn_pro_products.Product_Number) Like Concat('%',
      Lower(@ProductNumberContains), '%'))) And
  (@ActiveComponentContains Is Null Or
    (@ActiveComponentContains Is Not Null And
      hec_products.HEC_ProductID In (Select
        hec_pro_product_components.HEC_PRO_Product_RefID
      From
        hec_pro_product_components Inner Join
        hec_pro_components On hec_pro_product_components.HEC_PRO_Component_RefID
          = hec_pro_components.HEC_PRO_ComponentID And
          hec_pro_components.IsDeleted = 0 Inner Join
        hec_pro_component_substanceingredients
          On hec_pro_components.HEC_PRO_ComponentID =
          hec_pro_component_substanceingredients.Component_RefID And
          hec_pro_component_substanceingredients.IsDeleted = 0 Inner Join
        hec_sub_substances
          On hec_pro_component_substanceingredients.Substance_RefID =
          hec_sub_substances.HEC_SUB_SubstanceID And
          hec_sub_substances.IsDeleted = 0
      Where
        hec_pro_product_components.IsDeleted = 0 And
        hec_pro_product_components.Tenant_RefID = @TenantID And
        Upper(hec_sub_substances.GlobalPropertyMatchingID) Like Concat('%',
        Upper(@ActiveComponentContains), '%')))) And
  (@ActiveComponentStartWith Is Null Or
    (@ActiveComponentStartWith Is Not Null And
      Lower(hec_sub_substances.GlobalPropertyMatchingID) Like
      Concat(Lower(@ActiveComponentStartWith), '%')))
Group By
  cmn_pro_products.CMN_PRO_ProductID, cmn_pro_products.Product_Number,
  hec_product_dosageforms.HEC_Product_DosageFormID,
  hec_product_dosageforms.GlobalPropertyMatchingID, cmn_units.CMN_UnitID,
  cmn_units.Label_DictID, cmn_pro_productgroups.GlobalPropertyMatchingID,
  cmn_pro_products.IsProductAvailableForOrdering, cmn_sls_prices.PriceAmount,
  cmn_currencies.ISO4127, cmn_currencies.Symbol,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel
Order By
  Quantity Desc
  