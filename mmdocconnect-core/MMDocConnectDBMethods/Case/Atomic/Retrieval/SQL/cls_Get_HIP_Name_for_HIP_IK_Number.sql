
Select
  cmn_bpt_businessparticipants.DisplayName As Name
From
  hec_his_healthinsurance_companies Inner Join
  cmn_bpt_businessparticipants
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
Where
  hec_his_healthinsurance_companies.IsDeleted = 0 And
  hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber = @HIPIKNumber
	