
    Select
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber As HipIK,
      cmn_ctr_contract_parameters.ParameterName ,
      cmn_ctr_contract_parameters.IfNumericValue_Value As ParameterValue
    From
      cmn_ctr_contract_parties Inner Join
      hec_his_healthinsurance_companies
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parameters
        On cmn_ctr_contract_parties.Contract_RefID = cmn_ctr_contract_parameters.Contract_RefID And
         (cmn_ctr_contract_parameters.ParameterName = 'Number of days between surgery and aftercare - Days' Or
          cmn_ctr_contract_parameters.ParameterName = 'Number of days between treatment and settlement claim - Days' Or
          cmn_ctr_contract_parameters.ParameterName = 'Preexaminations - Days' Or
          cmn_ctr_contract_parameters.ParameterName = 'Max number of preexaminations') And
      cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
      cmn_ctr_contract_parameters.IsDeleted = 0
    Where
	    cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
	    cmn_ctr_contract_parties.IsDeleted = 0 
  