
    Select
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID as ContractID,
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID as GposID
    From
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
      Inner Join hec_crt_insurancetobrokercontracts On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
    Where
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
	