
    Select
      hec_patient_healthinsurances.Patient_RefID as patient_id,
      cmn_ctr_contract_parameters.IfNumericValue_Value as days
    From
      hec_patient_healthinsurances Inner Join
      hec_his_healthinsurance_companies
        On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parties
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
        cmn_ctr_contract_parties.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parameters
        On cmn_ctr_contract_parties.Contract_RefID = cmn_ctr_contract_parameters.Contract_RefID And    
  	    cmn_ctr_contract_parameters.ParameterName = 'Number of days between surgery and aftercare - Days' And
  	    cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
  	    cmn_ctr_contract_parameters.IsDeleted = 0
    Where
	    hec_patient_healthinsurances.Tenant_RefID = @TenantID And
	    hec_patient_healthinsurances.IsDeleted = 0
    Group by patient_id
	