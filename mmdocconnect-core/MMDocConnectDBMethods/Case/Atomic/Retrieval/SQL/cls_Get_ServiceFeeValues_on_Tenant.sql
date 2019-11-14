
    Select
      hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_String As service_fee,
      hec_bil_potentialcodes.BillingCode As GposNumber
    From
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
      Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty On hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_RefID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID And
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Tenant_RefID = @TenantID And
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.IsDeleted = 0
      Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
        On hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_UniversalProperty_RefID =
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.Tenant_RefID = @TenantID And
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsDeleted = 0 And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsValue_String = 1 And
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.PropertyName = 'Service Fee in EUR'
      Inner Join hec_bil_potentialcodes On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID And hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0
      Inner Join hec_crt_insurancetobrokercontracts On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
      Inner Join cmn_ctr_contracts On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contracts.CMN_CTR_ContractID And
      cmn_ctr_contracts.Tenant_RefID = @TenantID And
      cmn_ctr_contracts.IsDeleted = 0
    Where
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
    Group By
      hec_bil_potentialcodes.BillingCode
	