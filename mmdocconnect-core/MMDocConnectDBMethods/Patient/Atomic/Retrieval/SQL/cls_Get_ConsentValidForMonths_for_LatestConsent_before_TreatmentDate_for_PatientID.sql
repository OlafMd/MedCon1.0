
    Select
      cmn_ctr_contract_parameters.IfNumericValue_Value as consent_valid_for_months
    From
      hec_crt_insurancetobrokercontract_participatingpatients Inner Join
      hec_crt_insurancetobrokercontracts
        On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parameters
        On hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = cmn_ctr_contract_parameters.Contract_RefID And
  	    cmn_ctr_contract_parameters.ParameterName = 'Duration of participation consent – Month' And
  	    cmn_ctr_contract_parameters.Tenant_RefID = @TenantID And
  	    cmn_ctr_contract_parameters.IsDeleted = 0
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientID And
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom <= @TreatmentDate And
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
    Order by
	    hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom desc
    Limit 1
  