
Select
  hec_doctors.HEC_DoctorID,
  hec_doctors.DoctorIDNumber,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.BusinessParticipantITL,
  cmn_per_personinfo.Title,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID As
  CMN_BPT_BusinessParticipantID1
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID And (cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted Is Null Or cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0) Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID And (cmn_bpt_businessparticipants1.IsDeleted Is Null Or cmn_bpt_businessparticipants1.IsDeleted = 0) Left Join
  cmn_addresses On cmn_per_personinfo.Address_RefID =
    cmn_addresses.CMN_AddressID And (cmn_addresses.IsDeleted Is Null Or
      cmn_addresses.IsDeleted = 0)
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0
  and hec_doctors.Tenant_RefID = @TenantID
Order By
  hec_doctors.Creation_Timestamp Desc
  