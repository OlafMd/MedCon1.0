
    Select
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom as consent_valid_from,
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID as contract_id,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough as consent_valid_through
    From
      hec_crt_insurancetobrokercontract_participatingdoctors Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = @GposIDs And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
      hec_crt_insurancetobrokercontracts
        On hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID = @DoctorID And
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom <= @Date And
      (hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough = '0001-01-01' Or
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough >= @Date) And
      hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0  
    Order by 
    	consent_valid_from desc
	