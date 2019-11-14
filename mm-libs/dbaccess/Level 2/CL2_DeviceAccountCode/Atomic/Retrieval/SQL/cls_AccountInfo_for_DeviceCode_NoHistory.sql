
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipant_accesscodes.CMN_BPT_BusinessParticipant_AccessCodeID,
  cmn_bpt_businessparticipants.Tenant_RefID,
  cmn_bpt_businessparticipant_accesscodes.Code
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipant_accesscodes.Code = @DeviceCode
  