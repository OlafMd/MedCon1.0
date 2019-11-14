
Select
  hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID,
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID,
  cmn_ctr_contracts.ContractName
From
  hec_bil_potentialcode_catalogs Inner Join
  hec_bil_potentialcodes
    On hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID = hec_bil_potentialcodes.PotentialCode_Catalog_RefID And
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
    On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses
    On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID =
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0 Inner Join
  hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
    On hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID =
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID And
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID = @TenantID And
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 Inner Join
  hec_crt_insurancetobrokercontracts
    On hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID =
    hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And 
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
    hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
  cmn_ctr_contracts
    On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contracts.CMN_CTR_ContractID And
    cmn_ctr_contracts.Tenant_RefID = @TenantID And
    cmn_ctr_contracts.IsDeleted = 0
Where
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID Like '%voruntersuchung%' And
  hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
  hec_bil_potentialcode_catalogs.IsDeleted = 0
Limit 1
	