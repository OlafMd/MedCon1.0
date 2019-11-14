
Select
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Contact_Email As PracticeEmail,
  cmn_universalcontactdetails.Street_Name_Line2,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
  cmn_com_companyinfo.CMN_COM_CompanyInfoID,
  hec_medicalpractises.WeeklySurgeryHours_Template_RefID,
  hec_medicalpractises.WeeklyOfficeHours_Template_RefID,
  hec_medicalpractises.AssociatedWith_PhysitianAssociation_RefID,
  cmn_com_companyinfo.CompanyType_RefID,
  hec_medicalpractises.ContactPerson_RefID,
  cmn_universalcontactdetails.Region_Name,
  cmn_universalcontactdetails.Contact_Website_URL,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  hec_medicalpractises.Contact_EmergencyPhoneNumber,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID
From
  hec_medicalpractises Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0
Where
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_medicalpractises.HEC_MedicalPractiseID = @HEC_MedicalPractiseID
  