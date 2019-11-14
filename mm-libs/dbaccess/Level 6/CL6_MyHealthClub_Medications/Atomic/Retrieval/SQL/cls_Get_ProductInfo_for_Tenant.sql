
Select
  hec_products.HEC_ProductID,
  hec_products.Ext_PRO_Product_RefID,
  hec_products.Recepie,
  hec_products.ProductDosageForm_RefID,
  hec_products.IsProduct_OverTheCounter,
  hec_products.IsProduct_PrescriptionRequired,
  hec_products.IsProduct_HospitalPackage,
  hec_products.IsProduct_AddictiveDrug,
  hec_products.ProductDistributionStatus,
  cmn_units.ISOCode,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  hec_products.IsDeleted,
  cmn_bpt_businessparticipants.DisplayName,
  hec_products.Creation_Timestamp,
  hec_products.Tenant_RefID,
  cmn_pro_products.Product_Name_DictID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_pro_products.Modification_Timestamp As Modification_TimestampProducts,
  hec_products.Modification_Timestamp As Modification_TimestampHecProducts,
  cmn_bpt_businessparticipants.Modification_Timestamp As Modification_TimestampBpart,
  cmn_pro_pac_packageinfo.Modification_Timestamp As Modification_TimestampPackageInfo,
  cmn_units.Modification_Timestamp As Modification_TimestampUnits,
  hec_product_dosageforms.Modification_Timestamp As Modification_TimestampDosageForms
From
  hec_products Inner Join
  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_pro_products.ProducingBusinessParticipant_RefID Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID =
    cmn_pro_products.PackageInfo_RefID Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID
Where
  hec_products.Tenant_RefID = @Tenant
  