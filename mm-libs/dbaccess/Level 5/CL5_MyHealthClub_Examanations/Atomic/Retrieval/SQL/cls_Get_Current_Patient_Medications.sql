
Select
  hec_patient_medications.HEC_Patient_MedicationID,
  hec_patient_medications.R_DateOfAdding,
  hec_patient_medications.R_ActiveUntill,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  cmn_units.ISOCode
From
  hec_patient_medications Inner Join
  hec_products On hec_patient_medications.R_HEC_Product_RefID =
    hec_products.HEC_ProductID And hec_products.IsDeleted = 0 And
    hec_products.Tenant_RefID = @TenantID Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID And
    hec_product_dosageforms.Tenant_RefID = @TenantID And
    hec_product_dosageforms.IsDeleted = 0 Inner Join
  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID And cmn_pro_products.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
    cmn_pro_pac_packageinfo.IsDeleted = 0 And
    cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID Left Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID And cmn_units.IsDeleted = 0 And
    cmn_units.Tenant_RefID = @TenantID
Where
  hec_patient_medications.R_ActiveUntill > CurDate() And
  hec_patient_medications.Patient_RefID = @PatientID And
  hec_patient_medications.R_IsActive = 1 And
  hec_patient_medications.IsDeleted = 0 And
  hec_patient_medications.Tenant_RefID = @TenantID And
  hec_patient_medications.R_IsSubstance = 0
  