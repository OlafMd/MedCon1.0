
    Select
      hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID As InsuranceToBrokerContractID,
      hec_patient_healthinsurances.Patient_RefID As PatientID
    From
      hec_patient_healthinsurances
      Inner Join hec_his_healthinsurance_companies
        On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
        hec_his_healthinsurance_companies.IsDeleted = 0 And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID 
      Inner Join cmn_ctr_contract_parties
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        cmn_ctr_contract_parties.IsDeleted = 0 And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID 
      Inner Join hec_crt_insurancetobrokercontracts
        On cmn_ctr_contract_parties.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID
    Where
      hec_patient_healthinsurances.Tenant_RefID = @TenantID And
      hec_patient_healthinsurances.IsDeleted = 0 And
       hec_patient_healthinsurances.Patient_RefID = @PatientIDs
  