
    Select
      hec_crt_insurancetobrokercontract_participatingdoctors.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID as AssignmentID,
      cmn_ctr_contracts.ContractName as ConsentContractName,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom as ConsentValidFrom,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough as ConsentValidThrough
    From
      hec_crt_insurancetobrokercontract_participatingdoctors
      Inner Join hec_crt_insurancetobrokercontracts On hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
      Inner Join cmn_ctr_contracts On cmn_ctr_contracts.CMN_CTR_ContractID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
      cmn_ctr_contracts.Tenant_RefID = @TenantID And cmn_ctr_contracts.IsDeleted = 0 And
      cmn_ctr_contracts.CMN_CTR_ContractID = @ContractID
    Where
      hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
      hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID = @DoctorID 
	
  