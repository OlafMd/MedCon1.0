
Select
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_products.HEC_ProductID,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_pac_packageinfo.PackageContent_Amount As Strength_Amount,
  cmn_units.ISOCode As Strength_Unit,
  hec_dosages.DosageText,
  hec_dia_potentialdiagnoses.DefaultTimeUntillDeactivation_InDays
From
  hec_dia_potentialdiagnoses Left Join
  hec_dia_recommendedproducts
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_recommendedproducts.PotentialDiagnosis_RefID And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_dia_recommendedproducts.IsDeleted = 0 And
    hec_dia_recommendedproducts.Tenant_RefID = @TenantID And
    hec_dia_recommendedproducts.IsDefault = 1 Left Join
  hec_products On hec_dia_recommendedproducts.HealthcareProduct_RefID =
    hec_products.HEC_ProductID And hec_products.Tenant_RefID = @TenantID And
    hec_products.IsDeleted = 0 Left Join
  cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID Left Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
    cmn_pro_pac_packageinfo.IsDeleted = 0 And
    cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID Left Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID And cmn_units.IsDeleted = 0 And
    cmn_units.Tenant_RefID = @TenantID Left Join
  hec_dia_recommendedproduct_dosages
    On hec_dia_recommendedproduct_dosages.RecommendedProduct_RefID =
    hec_dia_recommendedproducts.HEC_DIA_RecommendedProductID And
    hec_dia_recommendedproduct_dosages.IsDeleted = 0 And
    hec_dia_recommendedproduct_dosages.Tenant_RefID = @TenantID Left Join
  hec_dosages
    On hec_dosages.HEC_DosageID =
    hec_dia_recommendedproduct_dosages.Dosage_RefID And hec_dosages.IsDeleted =
    0 And hec_dosages.Tenant_RefID = @TenantID
Where
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID = @DiagnosisID And
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID
  