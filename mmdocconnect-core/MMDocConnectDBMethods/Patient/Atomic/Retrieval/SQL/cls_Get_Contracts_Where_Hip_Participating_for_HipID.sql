
    Select
      cmn_ctr_contracts.ContractName,
      cmn_ctr_contracts.CMN_CTR_ContractID As ContractID,
      cmn_ctr_contracts.ValidFrom,
      cmn_ctr_contracts.ValidThrough,
      cmn_ctr_contract_parameters.IfNumericValue_Value As ParticipationConsentValidForMonths
    From
      cmn_ctr_contract_parties
      Inner Join cmn_ctr_contract_roles On cmn_ctr_contract_parties.Party_ContractRole_RefID = cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID And cmn_ctr_contract_roles.RoleName =
        'Health Insurance Provider' And cmn_ctr_contract_roles.Tenant_RefID = @TenantID And cmn_ctr_contract_roles.IsDeleted = 0
      Inner Join cmn_ctr_contracts On cmn_ctr_contract_parties.Contract_RefID = cmn_ctr_contracts.CMN_CTR_ContractID And cmn_ctr_contracts.Tenant_RefID = @TenantID And
        cmn_ctr_contracts.IsDeleted = 0
      Inner Join cmn_ctr_contract_parameters On cmn_ctr_contracts.CMN_CTR_ContractID = cmn_ctr_contract_parameters.Contract_RefID And cmn_ctr_contract_parameters.ParameterName =
        'Duration of participation consent – Month' And cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And cmn_ctr_contract_parameters.IsDeleted = 0
      Inner Join hec_his_healthinsurance_companies On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID And
        hec_his_healthinsurance_companies.HealthInsurance_IKNumber = @HipIkNumber And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0
    Where
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID
    Order by
      cmn_ctr_contracts.Creation_Timestamp
	