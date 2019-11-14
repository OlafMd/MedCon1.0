
	Select
  cmn_bpt_businessparticipants.DisplayName,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Contact_Email,
  cmn_universalcontactdetails.Contact_Telephone, 
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.IsCompany,  
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID Inner Join
  hec_medicalpractises On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_per_personinfo On hec_medicalpractises.ContactPerson_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_medicalpractice_2_practicetype
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID Left Join
  hec_medicalpractice_types
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID
Where
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = IfNull(@CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID) And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsDeleted = 0
  