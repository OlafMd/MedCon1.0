
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID as patient_id,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom as consent_valid_from,
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID as contract_id,
      hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID as insurance_to_broker_contract_id
    From
      hec_crt_insurancetobrokercontract_participatingpatients Inner Join
      hec_crt_insurancetobrokercontracts
        On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientIDs And
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0  
  