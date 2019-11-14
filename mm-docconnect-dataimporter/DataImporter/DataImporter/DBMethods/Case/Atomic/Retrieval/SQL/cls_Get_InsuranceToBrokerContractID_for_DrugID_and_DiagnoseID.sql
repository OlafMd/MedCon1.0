
    Select
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID As insurance_to_broker_contract,
      cmn_ctr_contracts.ValidThrough As contract_valid_through,
      cmn_ctr_contracts.ContractName As contract_name,
      cmn_ctr_contract_parameters.IfNumericValue_Value As contract_consent_valid_for_months,
      cmn_ctr_contracts.CMN_CTR_ContractID As contract_id,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom As patient_consent_valid_from
    From
      hec_crt_insurancetobrokercontract_participatingpatients
      Inner Join hec_crt_insurancetobrokercontracts On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID
      Inner Join cmn_ctr_contracts On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contracts.CMN_CTR_ContractID And
        cmn_ctr_contracts.Tenant_RefID = @TenantID And
        cmn_ctr_contracts.IsDeleted = 0
      Inner Join hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts On hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 And
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID = @DrugID
      Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0 And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID = @DiagnoseID
      Left Join cmn_ctr_contract_parameters On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contract_parameters.Contract_RefID And
        cmn_ctr_contract_parameters.ParameterName = 'Duration of participation consent – Month' And
        cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
        cmn_ctr_contract_parameters.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom <= @TreatmentDate And
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientID And
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      (hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0 Or 
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = @TakeExpiredConsentsIntoAccount)
    Order by
      cmn_ctr_contracts.ValidFrom
	