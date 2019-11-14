
    Select Distinct
      cmn_pro_products_de.Content As DrugName,
      hec_products.HEC_ProductID As DrugID,
      cmn_pro_products.Product_Number As DrugPZN
    From
      hec_products
      Inner Join cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
        cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.Tenant_RefID =
        @TenantID And cmn_pro_products.IsDeleted = 0
      Inner Join cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
        cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0
    Where
      (Lower(cmn_pro_products_de.Content) Like @SearchCriteria Or
      Lower(cmn_pro_products.Product_Number) Like @SearchCriteria) And
      hec_products.Tenant_RefID = @TenantID And
      hec_products.IsDeleted = 0
  