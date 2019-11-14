
    Select
      cmn_ctr_contract_parameters.CMN_CTR_Contract_ParameterID As ID,
      cmn_ctr_contract_parameters.ParameterName As Name,
      cmn_ctr_contract_parameters.IfNumericValue_Value As Value
    From
      cmn_ctr_contract_parameters
    Where
      cmn_ctr_contract_parameters.IsNumericValue = 1 And
      cmn_ctr_contract_parameters.Contract_RefID = @ContractID And
      cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parameters.IsDeleted = 0
  