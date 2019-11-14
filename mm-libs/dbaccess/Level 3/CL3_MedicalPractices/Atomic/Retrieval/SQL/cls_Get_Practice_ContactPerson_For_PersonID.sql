
Select
  cmn_bpt_businessparticipants.DisplayName As Ophthal_ContactPerson,
  cmn_per_personinfo.FirstName As Luc_ContactPerFName,
  cmn_per_personinfo.LastName As Luc_ContactPerLName,
  cmn_per_personinfo.PrimaryEmail As Luc_ContactPerEmail,
  cmn_per_communicationcontacts.Contact_Type As Luc_ContactPerPhoneID,
  cmn_per_communicationcontacts.Content As Luc_ContactPerPhone,
  cmn_per_personinfo.CMN_PER_PersonInfoID
From
  cmn_bpt_businessparticipants Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
  Left Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    cmn_per_communicationcontacts.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
  @CMN_BPT_BusinessParticipantID And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  