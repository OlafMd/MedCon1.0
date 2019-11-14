
Select
  hec_doctors.HEC_DoctorID,
  hec_doctors.DoctorIDNumber As LANR,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontacts.Contact_Type,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As
  Doctor_CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_per_personinfo.Title,
  hec_doctors.Account_RefID,
  cmn_per_personinfo.PrimaryEmail As LoginEmail
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID
Where
  hec_doctors.HEC_DoctorID = @DoctorID And
  (cmn_per_communicationcontacts.IsDeleted = 0 Or
    cmn_per_communicationcontacts.IsDeleted Is Null) And
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_doctors.Tenant_RefID = @TenantID
  