
    Select
      cmn_bpt_businessparticipants.DisplayName,
      cmn_ctr_contract_roles.RoleName,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom,
      hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough,
      cmn_ctr_contracts.ContractName,
      cmn_ctr_contracts.CMN_CTR_ContractID,
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID as HIPID,
      hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID,
      hec_crt_insurancetobrokercontract_participatingdoctors.HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID As DoctorAssignment
    From
      hec_crt_insurancetobrokercontracts Right Join
      hec_crt_insurancetobrokercontract_participatingdoctors
        On
        hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
        hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID = @DoctorID
         Inner Join
      cmn_ctr_contracts On cmn_ctr_contracts.CMN_CTR_ContractID =
        hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
      cmn_ctr_contracts.Tenant_RefID = @TenantID And
      cmn_ctr_contracts.IsDeleted = 0 
        Left Join
      cmn_ctr_contract_parties On cmn_ctr_contract_parties.Contract_RefID =
        cmn_ctr_contracts.CMN_CTR_ContractID And
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parties.IsDeleted = 0 
        Left Join
      cmn_ctr_contract_roles On cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID =
        cmn_ctr_contract_parties.Party_ContractRole_RefID 
        Left Join
      cmn_bpt_businessparticipants
        On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
      cmn_bpt_businessparticipants.IsDeleted = 0 And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID 
    Where
      hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
      hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID    And          
      (cmn_ctr_contract_roles.RoleName = 'Health Insurance Provider' Or cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID is null)
  
  
  