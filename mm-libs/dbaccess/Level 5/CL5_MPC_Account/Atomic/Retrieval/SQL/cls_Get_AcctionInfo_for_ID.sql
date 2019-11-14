
Select
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Country_Name,
  hec_cmt_memberships.HEC_CMT_MembershipID,
  hec_cmt_community_offeredmembershiptypes.IsAvailableFor_Tenants,
  hec_cmt_community_offeredmembershiptypes.IsAvailableFor_Doctors,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_usr_users.CMN_BPT_USR_UserID
From
  cmn_bpt_usr_users Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_usr_users.BusinessParticipant_RefID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_addresses On cmn_per_personinfo.Address_RefID =
    cmn_addresses.CMN_AddressID Inner Join
  hec_cmt_memberships On cmn_bpt_usr_users.BusinessParticipant_RefID =
    hec_cmt_memberships.BusinessParticipant_RefID Inner Join
  hec_cmt_community_offeredmembershiptypes
    On
    hec_cmt_community_offeredmembershiptypes.HEC_CMT_Community_OfferedMembershipTypeID = hec_cmt_memberships.MembershipType_RefID
Where
  cmn_bpt_usr_users.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_addresses.IsDeleted = 0 And
  cmn_bpt_usr_users.CMN_BPT_USR_UserID = @CMN_BPT_USR_UserID And
  hec_cmt_memberships.IsDeleted = 0 And
  hec_cmt_community_offeredmembershiptypes.IsDeleted = 0
  