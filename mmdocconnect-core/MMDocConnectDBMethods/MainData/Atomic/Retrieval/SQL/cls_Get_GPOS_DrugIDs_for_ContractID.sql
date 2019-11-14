
    Select
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID As GposID,
      hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID As DrugID,
      cmn_pro_products_de.Content As DrugName
    From
      hec_crt_insurancetobrokercontracts
      Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
      Inner Join hec_bil_potentialcode_2_healthcareproduct
        On
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID And hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID And hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0
      Inner Join hec_products
        On hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID =
        hec_products.HEC_ProductID And hec_products.Tenant_RefID =
        @TenantID And hec_products.IsDeleted = 0
      Inner Join cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
        cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.Tenant_RefID =
        @TenantID And cmn_pro_products.IsDeleted = 0
      Inner Join cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
        cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID
    Group By
      hec_bil_potentialcode_2_healthcareproduct.AssignmentID
    Order By
      lower(cmn_pro_products_de.Content)
  