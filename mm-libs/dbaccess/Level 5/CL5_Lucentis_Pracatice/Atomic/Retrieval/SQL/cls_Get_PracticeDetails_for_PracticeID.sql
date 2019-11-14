
	Select
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Street_Number,
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  hec_medicalpractises.HEC_MedicalPractiseID
From
  hec_medicalpractises Left Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID And
    cmn_bpt_businessparticipants.IsCompany = 1 Left Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.IsCompany = 1
Where
  hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID And
  hec_medicalpractises.IsDeleted = 0 And
  hec_medicalpractises.Tenant_RefID = @TenantID
  