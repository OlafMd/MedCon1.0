
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.DefaultStorageTemperature_max_in_kelvin,
  cmn_pro_products.DefaultStorageTemperature_min_in_kelvin,
  cmn_pro_products.DefaultExpirationPeriod_in_sec,
  cmn_pro_products.ProductSuccessor_RefID,
  cmn_pro_products.IsStorage_CoolingRequired,
  cmn_pro_products.IsStorage_BatchNumberMandatory,
  cmn_pro_products.IsStorage_ExpiryDateMandatory,
  cmn_pro_products.IsProductPartOfDefaultStock,
  cmn_pro_productcodes.ProductCode_Value,
  hec_products.ProductDosageForm_RefID,
  hec_products.IsProduct_AddictiveDrug,
  cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID,
  cmn_pro_products.ProductType_RefID,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  cmn_pro_pac_packageinfo.PackageContent_DisplayLabel,
  cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID,
  cmn_pro_products1.Product_Name_DictID As Product_Name_Successor,
  cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_pro_products.ProductITL,
  cmn_units.ISOCode,
  cmn_pro_products.ProductAdditionalInfoXML,
  cmn_pro_products.IsPlaceholderArticle,
  cmn_pro_productgroups.GlobalPropertyMatchingID,
  cmn_pro_productgroups.CMN_PRO_ProductGroupID,
  cmn_bpt_businessparticipants.DisplayName  As ProducerName
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  cmn_pro_product_2_productgroup
    On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID Left Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID Left Join
  cmn_pro_product_salestaxassignmnets
    On cmn_pro_product_salestaxassignmnets.Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  cmn_pro_product_2_productcode
    On cmn_pro_product_2_productcode.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  cmn_pro_products cmn_pro_products1 On cmn_pro_products.ProductSuccessor_RefID
    = cmn_pro_products1.CMN_PRO_ProductID And cmn_pro_products1.Tenant_RefID =
    @TenantID And cmn_pro_products1.IsDeleted = 0 Left Join
  cmn_pro_productcodes
    On cmn_pro_product_2_productcode.CMN_PRO_ProductCode_RefID =
    cmn_pro_productcodes.CMN_PRO_ProductCodeID Left Join
  cmn_pro_productcode_types On cmn_pro_productcodes.ProductCode_Type_RefID =
    cmn_pro_productcode_types.CMN_PRO_ProductCode_TypeID Inner Join
  cmn_pro_productgroups On cmn_pro_productgroups.CMN_PRO_ProductGroupID =
    cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID Left Join
  cmn_bpt_businessparticipants
    On cmn_pro_products.ProducingBusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  cmn_pro_products.CMN_PRO_ProductID = @ArticleID And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.IsProduct_Article = True And
  cmn_pro_products.Tenant_RefID = @TenantID
  