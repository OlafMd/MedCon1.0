
    Select 
      cmn_pro_products_de.Content As drug_name,
      hec_products.HEC_ProductID As drug_id,
      cmn_pro_products.Product_Number as drug_pzn
    From
      cmn_ctr_contracts Inner Join
      hec_crt_insurancetobrokercontracts On cmn_ctr_contracts.CMN_CTR_ContractID =
        hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        cmn_ctr_contracts.Tenant_RefID = @TenantID And cmn_ctr_contracts.IsDeleted =
        0 Inner Join
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
        On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID = @TenantID And hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 Inner Join
      hec_products
        On
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID = hec_products.HEC_ProductID And
        hec_products.Tenant_RefID = @TenantID And
        hec_products.IsDeleted = 0
        Inner Join
      cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
        cmn_pro_products.CMN_PRO_ProductID And
        cmn_pro_products.Tenant_RefID = @TenantID And
        cmn_pro_products.IsDeleted = 0
         Inner Join
      cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
        cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0
    Where
      cmn_ctr_contracts.CMN_CTR_ContractID = @ContractIDs And
      cmn_ctr_contracts.Tenant_RefID = @TenantID And
      cmn_ctr_contracts.IsDeleted = 0 
    Group By
      hec_products.HEC_ProductID
    Order By
      null
	