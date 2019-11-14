
    Select
      cmn_pro_products_de.Content As drug_name,
      hec_products.HEC_ProductID As drug_id
    From
      hec_products Inner Join
      cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
        cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.Tenant_RefID =
        @TenantID And cmn_pro_products.IsDeleted = 0 Inner Join
      cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
        cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0
    Where
      hec_products.Tenant_RefID = @TenantID And
      hec_products.IsDeleted = 0 And
      hec_products.HEC_ProductID = @DrugID
    Group By
      hec_products.HEC_ProductID
	