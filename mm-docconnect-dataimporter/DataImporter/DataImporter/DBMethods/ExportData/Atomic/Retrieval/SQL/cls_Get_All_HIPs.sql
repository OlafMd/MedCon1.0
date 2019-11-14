
    Select
      cmn_bpt_businessparticipants.DisplayName As name,
      hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID As id,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber
    From
      cmn_bpt_businessparticipants Inner Join
      hec_his_healthinsurance_companies
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        hec_his_healthinsurance_companies.IsDeleted = 0 And hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
    Where
      cmn_bpt_businessparticipants.IsCompany = 1 And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
      cmn_bpt_businessparticipants.IsDeleted = 0  
	