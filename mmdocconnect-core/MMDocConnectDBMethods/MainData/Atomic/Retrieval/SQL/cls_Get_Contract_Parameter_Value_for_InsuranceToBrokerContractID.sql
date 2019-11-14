
Select
  cmn_ctr_contract_parameters.IfNumericValue_Value As ConsentValidForMonths
From
  hec_crt_insurancetobrokercontracts
  Inner Join cmn_ctr_contract_parameters On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contract_parameters.Contract_RefID And
    cmn_ctr_contract_parameters.ParameterName = @ParameterName And cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
    cmn_ctr_contract_parameters.IsDeleted = 0
Where
  hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
  hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
  hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID = @InsuranceToBrokerContractID
  