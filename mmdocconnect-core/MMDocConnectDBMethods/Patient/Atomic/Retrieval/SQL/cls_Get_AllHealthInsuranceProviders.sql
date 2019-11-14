
    Select Distinct
      cmn_bpt_businessparticipants.DisplayName As name,
      hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID As id
    From
      cmn_ctr_contract_roles Inner Join
      cmn_ctr_contract_parties On cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID =
      cmn_ctr_contract_parties.Party_ContractRole_RefID And
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parties.IsDeleted = 0 And
      cmn_ctr_contract_parties.Contract_RefID = @ContractIDs
    Inner Join
      cmn_bpt_businessparticipants
        On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      hec_his_healthinsurance_companies
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
      hec_his_healthinsurance_companies.IsDeleted = 0 And
      hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
    Where
      cmn_ctr_contract_roles.IsDeleted = 0 And
      cmn_ctr_contract_roles.Tenant_RefID = @TenantID And
      cmn_ctr_contract_roles.RoleName = 'Health Insurance Provider' And
      cmn_bpt_businessparticipants.IsCompany = 1 And
      cmn_bpt_businessparticipants.IsNaturalPerson = 0 
    Order By
      lower(cmn_bpt_businessparticipants.DisplayName)
  
	