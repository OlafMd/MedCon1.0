
    Select
      cmn_bpt_businessparticipants.DisplayName As HipName,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber As HipNumber,
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As HipBptID
    From
      cmn_ctr_contract_parties
      Inner Join cmn_ctr_contract_roles
        On cmn_ctr_contract_parties.Party_ContractRole_RefID =
        cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID And
        cmn_ctr_contract_roles.Tenant_RefID = @TenantID And
        cmn_ctr_contract_roles.IsDeleted = 0 And cmn_ctr_contract_roles.RoleName =
        'Health Insurance Provider'
      Inner Join cmn_bpt_businessparticipants
        On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0
      Inner Join hec_his_healthinsurance_companies
        On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
        hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0
    Where
      cmn_ctr_contract_parties.Contract_RefID = @ContractID And
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parties.IsDeleted = 0
  