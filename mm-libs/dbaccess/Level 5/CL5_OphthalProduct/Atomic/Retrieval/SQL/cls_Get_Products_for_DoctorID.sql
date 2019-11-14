
    Select
      cmn_pro_products.Product_Name_DictID,
      cmn_pro_products.Product_Number,
      cmn_pro_products.Tenant_RefID,
      cmn_pro_products.Creation_Timestamp,
      cmn_pro_products.Product_Description_DictID,
      cmn_pro_products.CMN_PRO_ProductID,
      hec_doctor_requiredproduct.HEC_Doctor_RequiredProductID
    From
      cmn_pro_products Inner Join
      hec_doctor_requiredproduct On hec_doctor_requiredproduct.CMN_PRO_Product_RefID
        = cmn_pro_products.CMN_PRO_ProductID
    Where
      cmn_pro_products.IsDeleted = 0 And
      hec_doctor_requiredproduct.IsDeleted = 0 And
      hec_doctor_requiredproduct.HEC_Doctor_RefID = @DoctorID And
      cmn_pro_products.Tenant_RefID = @TenantID
  