
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.ProductITL,
  cmn_pro_products_de.Content As ProductName,
  cmn_pro_products.Product_Number,
  cmn_pro_products.IsProductPartOfDefaultStock,
  hec_products.ProductDistributionStatus,
  cmn_bpt_businessparticipants.DisplayName As ProducerName,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel As
  UnitAmount_DisplayLabel,
  cmn_units.ISOCode As UnitIsoCode,
  hec_product_dosageforms.GlobalPropertyMatchingID As DossageFormName,
  hec_sub_substances.IsActiveComponent,
  hec_sub_substances.GlobalPropertyMatchingID As SubstanceName,
  acc_tax_taxes.TaxRate,
  hec_sub_substances.HEC_SUB_SubstanceID
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID And
    hec_product_dosageforms.IsDeleted = 0 Left Join
  hec_pro_product_components On hec_products.HEC_ProductID =
    hec_pro_product_components.HEC_PRO_Product_RefID And
    hec_pro_product_components.IsDeleted = 0 Left Join
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
  cmn_units
    On cmn_units.CMN_UnitID =
    cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID And
    cmn_units.IsDeleted = 0 Left Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0 Left Join
  cmn_pro_product_salestaxassignmnets On cmn_pro_products.CMN_PRO_ProductID =
    cmn_pro_product_salestaxassignmnets.Product_RefID And
    cmn_pro_product_salestaxassignmnets.IsDeleted = 0 Left Join
  acc_tax_taxes On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
    = acc_tax_taxes.ACC_TAX_TaxeID And acc_tax_taxes.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants
    On cmn_pro_products.ProducingBusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0
Where
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.IsProduct_Article = 1 And
  cmn_pro_products.IsProductAvailableForOrdering =
  IfNull(@IsAvailableForOrdering,
  cmn_pro_products.IsProductAvailableForOrdering) And
  (@ProductNameStartWith Is Null Or
    (@ProductNameStartWith Is Not Null And
      Lower(cmn_pro_products_de.Content) Like
      Concat(Lower(@ProductNameStartWith), '%'))) And
  (@PZNOrName Is Null Or
    (@PZNOrName Is Not Null And
      (Upper(cmn_pro_products_de.Content) Like Upper(@PZNOrName) Or
        (Upper(cmn_pro_products.Product_Number) Like Upper(@PZNOrName)))))
 And
  (@Unit Is Null Or
    (@Unit Is Not Null And
      Upper(cmn_units.ISOCode) Like Upper(@Unit))) And
  (@DosageForm Is Null Or
    (@DosageForm Is Not Null And
      Upper(hec_product_dosageforms.GlobalPropertyMatchingID) Like
      Upper(@DosageForm))) And
  (@ActiveComponent Is Null Or
    (@ActiveComponent Is Not Null And
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
        Upper(hec_sub_substances.GlobalPropertyMatchingID) Like
        Upper(@ActiveComponent)))) And
  (@ProducerName Is Null Or
    (@ProducerName Is Not Null And
      Upper(cmn_bpt_businessparticipants.DisplayName) Like
      Upper(@ProducerName))) And
  (@ActiveComponentStartWith Is Null Or
    (@ActiveComponentStartWith Is Not Null And
      Lower(hec_sub_substances.GlobalPropertyMatchingID) Like
      Concat(Lower(@ActiveComponentStartWith), '%'))) And
  cmn_pro_products_de.Language_RefID = @LanguageID And
  (@IsDefaultStock Is Null Or
    cmn_pro_products.IsProductPartOfDefaultStock = @IsDefaultStock) And
  cmn_pro_products.IfImportedFromExternalCatalog_CatalogSubscription_RefID =
  0x00000000000000000000000000000000
  