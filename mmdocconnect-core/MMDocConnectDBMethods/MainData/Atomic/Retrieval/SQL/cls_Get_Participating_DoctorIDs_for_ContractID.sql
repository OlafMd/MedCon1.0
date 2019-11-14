
    Select
      hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID As DoctorID,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom As ConsentStartDate,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough As ConsentEndDate,
      Case When hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom <= Now() And (hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough = '0001-01-01' Or
        hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough >= Now()) Then true
         Else false End As IsConsentActive,
    hec_crt_insurancetobrokercontract_participatingdoctors.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID As DoctorAssignmentID
      From
        hec_crt_insurancetobrokercontract_participatingdoctors
        Inner Join hec_crt_insurancetobrokercontracts On hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID =
          hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And                
          hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
          hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
          hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID
      Where
        hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
        hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID
  