
Select
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID As InsuranceToBrokerContractID,
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As ContractID
From
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes Inner Join
  hec_bil_potentialcodes
    On
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And 
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And 
    hec_bil_potentialcodes.IsDeleted = 0 Inner Join
  hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
    hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
    hec_bil_potentialcode_catalogs.IsDeleted = 0 And
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID =
    'mm.docconnect.gpos.catalog.voruntersuchung' Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And 
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And 
    hec_crt_insurancetobrokercontracts.IsDeleted = 0
Where
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID =
  @TenantID And
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
  