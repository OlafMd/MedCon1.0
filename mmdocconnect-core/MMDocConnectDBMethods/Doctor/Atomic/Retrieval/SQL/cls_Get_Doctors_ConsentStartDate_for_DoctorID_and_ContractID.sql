
    Select Distinct
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom As ConsentStartDate
    From
      hec_crt_insurancetobrokercontracts
      Inner Join hec_crt_insurancetobrokercontract_participatingdoctors On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID And hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
        hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom <= Now() And 
       (hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough = '0001.01.01' Or hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough >= Now())
    Where
      hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID And
      hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID = @DoctorID
	