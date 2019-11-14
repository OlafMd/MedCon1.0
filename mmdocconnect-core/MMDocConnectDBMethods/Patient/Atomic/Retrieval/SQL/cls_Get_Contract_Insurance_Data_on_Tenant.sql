
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom as ConsentValidFrom,
      cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID As HipBptID,
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID As PatientID
    From
      cmn_ctr_contract_parties
      Inner Join hec_crt_insurancetobrokercontracts On cmn_ctr_contract_parties.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
      Inner Join hec_crt_insurancetobrokercontract_participatingpatients On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID = hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID And
        hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID 
    Where
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parties.IsDeleted = 0
    Order by
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom desc
	