
Select
  cmn_ctr_contract_parameters.IfNumericValue_Value As NumberOfOCTs
From
  cmn_ctr_contracts Inner Join
  cmn_ctr_contract_parameters
    On cmn_ctr_contracts.CMN_CTR_ContractID =
    cmn_ctr_contract_parameters.Contract_RefID And
    cmn_ctr_contract_parameters.ParameterName = 'Max number of preexaminations'
    And cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
    cmn_ctr_contract_parameters.IsDeleted = 0
Where
  cmn_ctr_contracts.ContractName = @ContractName And
  cmn_ctr_contracts.Tenant_RefID = @TenantID And
  cmn_ctr_contracts.IsDeleted = 0
  