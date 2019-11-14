
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom As
      participationFrom,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidThrough
      As partiicipationThrough,
      cmn_ctr_contracts.ContractName,
      cmn_ctr_contracts.ValidFrom As contractValidFrom,
      cmn_ctr_contracts.ValidThrough As contractValidThrough,
      hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,
      cmn_ctr_contracts.CMN_CTR_ContractID as contractID,
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID As PatientID
    From
      hec_crt_insurancetobrokercontract_participatingpatients Inner Join
      hec_crt_insurancetobrokercontracts
        On
        hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
      cmn_ctr_contracts
        On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID =
        cmn_ctr_contracts.CMN_CTR_ContractID And cmn_ctr_contracts.Tenant_RefID =
        @TenantID And cmn_ctr_contracts.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
  