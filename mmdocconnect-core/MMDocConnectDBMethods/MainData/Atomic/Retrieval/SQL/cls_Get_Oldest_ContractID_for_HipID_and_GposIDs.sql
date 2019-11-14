
    Select
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As contract_id
    From
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes Inner Join
      hec_crt_insurancetobrokercontracts
        On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parties
        On cmn_ctr_contract_parties.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID And
        cmn_ctr_contract_parties.IsDeleted = 0 Inner Join
      hec_his_healthinsurance_companies
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID = @HipID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0
    Where
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = @GposIDs And
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
    Group by 
	    contract_id 
    Order by 
	    hec_crt_insurancetobrokercontracts.Creation_Timestamp 
    Limit 
	    1
  