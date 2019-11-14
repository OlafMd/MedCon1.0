
    Select
      cmn_ctr_contracts.ContractName,
      cmn_ctr_contracts.CMN_CTR_ContractID As ContractID,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom As ConsentValidFrom,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough As ConsentValidThrough,
      hec_crt_insurancetobrokercontract_participatingdoctors.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID As AssignmentID,
      hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID As DoctorID,
      cmn_ctr_contracts.ValidFrom as ContractValidFrom,
      cmn_ctr_contracts.ValidThrough as ContractValidThrough
    From
      hec_crt_insurancetobrokercontract_participatingdoctors
      Inner Join hec_crt_insurancetobrokercontracts On hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
      Inner Join cmn_ctr_contracts On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contracts.CMN_CTR_ContractID And cmn_ctr_contracts.Tenant_RefID =
        @TenantID And cmn_ctr_contracts.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingdoctors.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = @AssignmentID And
      hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0
	