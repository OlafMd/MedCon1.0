
Select
  cmn_ctr_contract_parameters.IfStringValue_Value As contractCharacteristicID
From
  cmn_ctr_contract_parameters
Where
  cmn_ctr_contract_parameters.ParameterName = 'Contract characteristic ID' And
  cmn_ctr_contract_parameters.Contract_RefID = @ContractID And
  cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
  cmn_ctr_contract_parameters.IsDeleted = 0

    