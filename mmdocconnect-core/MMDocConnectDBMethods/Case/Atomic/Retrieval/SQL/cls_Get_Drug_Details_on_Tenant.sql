
    Select
      cmn_pro_products_de.Content As DrugName,
      hec_products.HEC_ProductID As DrugID
    From
      cmn_pro_products
      Inner Join cmn_pro_products_de On cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID And
      cmn_pro_products_de.IsDeleted = 0
      Inner Join hec_products On hec_products.Ext_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID And
      hec_products.Tenant_RefID = @TenantID And
      hec_products.IsDeleted = 0
    Where
      cmn_pro_products.IsDeleted = 0 And
      cmn_pro_products.Tenant_RefID = @TenantID
    Group By
      hec_products.HEC_ProductID
	