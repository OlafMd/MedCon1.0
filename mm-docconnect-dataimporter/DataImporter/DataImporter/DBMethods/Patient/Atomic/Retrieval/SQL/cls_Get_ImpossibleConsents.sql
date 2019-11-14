
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID
    From
      hec_patient_healthinsurances Inner Join
      hec_crt_insurancetobrokercontract_participatingpatients
        On hec_patient_healthinsurances.Patient_RefID = hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID And
        hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
      Inner Join
      hec_his_healthinsurance_companies
        On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0 Left Join
      cmn_ctr_contract_parties
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
        cmn_ctr_contract_parties.IsDeleted = 0
    Where
      cmn_ctr_contract_parties.CMN_CTR_Contract_PartyID Is Null And
      hec_patient_healthinsurances.Tenant_RefID = @TenantID And
      hec_patient_healthinsurances.IsDeleted = 0
  