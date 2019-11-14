
    Select
      cmn_ctr_contracts.CMN_CTR_ContractID as ContractID,
      cmn_ctr_contracts.ContractName,
      cmn_ctr_contracts.ValidFrom,
      cmn_ctr_contracts.ValidThrough,
      Group_Concat(cmn_bpt_businessparticipants.DisplayName Order By
      cmn_bpt_businessparticipants.DisplayName Separator ', ') As HIPNames
    From
      cmn_ctr_contracts
      Left Join cmn_ctr_contract_parties On cmn_ctr_contracts.CMN_CTR_ContractID =
        cmn_ctr_contract_parties.Contract_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID
        And cmn_ctr_contract_parties.IsDeleted = 0
      Left Join cmn_bpt_businessparticipants
        On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0
      Left Join cmn_ctr_contract_roles
        On cmn_ctr_contract_parties.Party_ContractRole_RefID =
        cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID And
        cmn_ctr_contract_roles.IsDeleted = 0 And cmn_ctr_contract_roles.Tenant_RefID = @TenantID
    Where
      cmn_ctr_contracts.Tenant_RefID = @TenantID And
      cmn_ctr_contracts.IsDeleted = 0 And
      (cmn_ctr_contract_roles.RoleName = 'Health Insurance Provider' Or cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID is null)
    Group By
      cmn_ctr_contracts.CMN_CTR_ContractID
  