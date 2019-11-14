
Select
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As
  Practice_CMN_BPT_BusinessParticipantID,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_businessparticipants1.DisplayName As ContactPersonName,
  cmn_per_personinfo.FirstName As ContactTypeFirstName,
  cmn_per_personinfo.PrimaryEmail As ContactTypeEmail,
  cmn_per_personinfo.LastName As ContactTypeLastName,
  cmn_per_communicationcontacts.Contact_Type As ContactTypePhoneID,
  cmn_per_communicationcontacts.Content As ContactTypePhoneNumber,
  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR
From
  cmn_bpt_businessparticipants Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  hec_medicalpractises On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    hec_medicalpractises.Ext_CompanyInfo_RefID Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_medicalpractises.ContactPerson_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsDeleted = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
  Left Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    cmn_per_communicationcontacts.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID = cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID = @PracticeBussinessParticipant_RefID And
  cmn_bpt_businessparticipants2.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
Order By
  cmn_bpt_businessparticipants.DisplayName
	