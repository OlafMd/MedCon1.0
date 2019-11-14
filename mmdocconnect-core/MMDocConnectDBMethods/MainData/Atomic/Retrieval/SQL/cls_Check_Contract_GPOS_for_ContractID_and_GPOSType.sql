
    Select
      hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
    From
      hec_crt_insurancetobrokercontracts
      Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID =
        @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
      Inner Join hec_bil_potentialcodes On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0
      Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And hec_bil_potentialcode_catalogs.IsDeleted = 0 And hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposType
    Where
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID And
      hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
      hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID
  