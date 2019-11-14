
Select
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.ProductITL,
  cmn_units.ISOCode,
  cmn_pro_products.CMN_PRO_ProductID,
  acc_tax_taxes.TaxRate,
  hec_product_dosageforms.GlobalPropertyMatchingID As DosageForm,
  cmn_bpt_businessparticipants.DisplayName As Producer_DisplayName,
  hec_products.ProductDistributionStatus,
  hec_products.HEC_ProductID,
  cmn_pro_products.IsStorage_CoolingRequired,
  cmn_pro_products.DefaultExpirationPeriod_in_sec,
  cmn_pro_products.DefaultStorageTemperature_max_in_kelvin,
  cmn_pro_products.DefaultStorageTemperature_min_in_kelvin,
  hec_products.IsProduct_AddictiveDrug,
  cmn_pro_products.ProductAdditionalInfoXML,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel
From
  cmn_pro_catalog_products Inner Join
  cmn_pro_products On cmn_pro_catalog_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Left Join
  cmn_bpt_businessparticipants
    On cmn_pro_products.ProducingBusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_units
    On cmn_units.CMN_UnitID =
    cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID Inner Join
  cmn_pro_product_salestaxassignmnets
    On cmn_pro_product_salestaxassignmnets.Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  acc_tax_taxes On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
    = acc_tax_taxes.ACC_TAX_TaxeID
Where
  cmn_pro_catalog_products.IsDeleted = 0 And
  cmn_pro_catalog_products.CMN_PRO_Catalog_Revision_RefID = @RevisionID And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_product_salestaxassignmnets.IsDeleted = 0 And
  acc_tax_taxes.IsDeleted = 0
  