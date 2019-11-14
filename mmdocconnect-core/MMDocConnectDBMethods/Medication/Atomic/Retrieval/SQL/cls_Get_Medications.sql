
Select
  cmn_pro_products.CMN_PRO_ProductID As MedicationID,
  cmn_pro_products_de.Content As Medication,
  cmn_pro_products.IsProducable_Internally As ProprietaryDrug,
  cmn_pro_products.Product_Number As PZNScheme,
  hec_products.HEC_ProductID As HecDrugID
From
  cmn_pro_products
  Inner Join cmn_pro_products_de On cmn_pro_products_de.DictID =
    cmn_pro_products.Product_Name_DictID
  Inner Join hec_products On cmn_pro_products.CMN_PRO_ProductID =
    hec_products.Ext_PRO_Product_RefID And hec_products.Tenant_RefID = @TenantID
    And hec_products.IsDeleted = 0
Where
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID
Group By
  cmn_pro_products.CMN_PRO_ProductID
  