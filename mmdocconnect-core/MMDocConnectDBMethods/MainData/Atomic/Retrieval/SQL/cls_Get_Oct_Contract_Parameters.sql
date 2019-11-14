
    Select
      cmn_ctr_contract_parameters.ParameterName,
      cmn_ctr_contract_parameters.IfStringValue_Value,
      cmn_ctr_contract_parameters.IfNumericValue_Value,
      cmn_ctr_contract_parameters.IfBooleanValue_Value,
      cmn_ctr_contract_parameters.Contract_RefID
    From
      cmn_ctr_contract_parameters Inner Join
      hec_crt_insurancetobrokercontracts
        On cmn_ctr_contract_parameters.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
      hec_bil_potentialcodes
        On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID ANd
        hec_bil_potentialcodes.IsDeleted = 0 Inner Join
      hec_bil_potentialcode_catalogs
        On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposCatalogID And
        hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
        hec_bil_potentialcode_catalogs.IsDeleted = 0
    Where
	    cmn_ctr_contract_parameters.Tenant_RefID = @TenantID ANd
	    cmn_ctr_contract_parameters.IsDeleted = 0
    Group by 
      cmn_ctr_contract_parameters.CMN_CTR_Contract_ParameterID
    Order by 
      null
  