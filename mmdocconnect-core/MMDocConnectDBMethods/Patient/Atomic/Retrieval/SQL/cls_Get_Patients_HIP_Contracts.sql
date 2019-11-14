
    Select
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As contract_id
    From
      hec_crt_insurancetobrokercontracts
      Inner Join cmn_ctr_contract_parties On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contract_parties.Contract_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID And cmn_ctr_contract_parties.IsDeleted = 0
      Inner Join cmn_ctr_contract_roles On cmn_ctr_contract_parties.Party_ContractRole_RefID = cmn_ctr_contract_roles.CMN_CTR_Contract_RoleID And cmn_ctr_contract_roles.Tenant_RefID =
        @TenantID And cmn_ctr_contract_roles.IsDeleted = 0 And cmn_ctr_contract_roles.RoleName = 'Health Insurance Provider'
      Inner Join hec_his_healthinsurance_companies On cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID =
        hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0
      Inner Join hec_patient_healthinsurances On hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID = hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID And
      hec_patient_healthinsurances.Tenant_RefID = @TenantID And
      hec_patient_healthinsurances.Patient_RefID = @PatientID
    Where
      hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontracts.IsDeleted = 0
	