

    Select
  hec_his_healthinsurance_companies.HealthInsurance_IKNumber,
  cmn_bpt_businessparticipants.DisplayName,
  hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
From
  hec_his_healthinsurance_companies Inner Join
  cmn_bpt_businessparticipants
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID
Where
  hec_his_healthinsurance_companies.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_his_healthinsurance_companies.Tenant_RefID = @TenantID

  