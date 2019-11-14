
    Select
      cmn_bpt_businessparticipants.DisplayName As HipName,
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As HipBptID,
      hec_his_healthinsurance_companies.HealthInsurance_IKNumber As HipNumber
    From
      cmn_bpt_businessparticipants
      Inner Join hec_his_healthinsurance_companies
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
        hec_his_healthinsurance_companies.IsDeleted = 0
    Where
      (Lower(cmn_bpt_businessparticipants.DisplayName) Like @SearchCriteria Or
      Lower(hec_his_healthinsurance_companies.HealthInsurance_IKNumber) like @SearchCriteria) And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
      cmn_bpt_businessparticipants.IsDeleted = 0
  