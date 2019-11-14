
    Select
      hec_bil_potentialcodes.BillingCode,
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID,
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID
    From
      hec_crt_insurancetobrokercontracts Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
      hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
        On
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_RefID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.IsDeleted = 0 And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_Boolean = 1 Inner Join
      hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
        On
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsDeleted = 0 And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.PropertyName = 'Waive with order' Inner Join
      hec_bil_potentialcodes
        On
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
      hec_crt_insurancetobrokercontract_participatingpatients
        On
        hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientID And
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontracts.Tenant_RefID =
      @TenantID And
      hec_crt_insurancetobrokercontracts.IsDeleted = 0 
	