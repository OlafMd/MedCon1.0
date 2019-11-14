
Select
  cmn_ctr_contract_parameters.IfNumericValue_Value as number_of_days,
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID as contract_id
From
  hec_crt_insurancetobrokercontracts Inner Join
  cmn_ctr_contract_parameters
    On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID =
    cmn_ctr_contract_parameters.Contract_RefID And
  cmn_ctr_contract_parameters.ParameterName =
  'Number of days between surgery and aftercare - Days' And 
  cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
  cmn_ctr_contract_parameters.IsDeleted = 0
   Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses
    On
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0 And
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID = @DiagnoseID
    Inner Join
  hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
    On
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID = hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID And
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID = @TenantID And
    hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 And
  hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID = @DrugID
Where
  hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And            
  hec_crt_insurancetobrokercontracts.IsDeleted = 0 
	