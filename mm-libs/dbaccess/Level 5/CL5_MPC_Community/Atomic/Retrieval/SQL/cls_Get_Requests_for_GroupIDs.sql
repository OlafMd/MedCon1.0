
Select
  hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID,
  hec_cmt_groupsubscription_requests.CommunityGroup_RefID,
  hec_cmt_offeredroles.GlobalPropertyMatchingID As
  Role_GlobalPropertyMatchingID,
  hec_cmt_groupsubscriptions.HEC_CMT_GroupSubscriptionID,
  hec_cmt_groupsubscriptions.CommunityGroup_RefID As FromSubscritpion_GroupID,
  cmn_per_personinfo.FirstName As Member_FirstName,
  cmn_per_personinfo.LastName As Member_LastName,
  hec_cmt_memberships.HEC_CMT_MembershipID,
  cmn_bpt_usr_users.CMN_BPT_USR_UserID
From
  hec_cmt_groupsubscription_requests Inner Join
  hec_cmt_offeredroles_2_groupsubscriptionrequest
    On
    hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_GroupSubscription_Request_RefID = hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID Inner Join
  hec_cmt_offeredroles
    On hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_OfferedRole_RefID
    = hec_cmt_offeredroles.HEC_CMT_OfferedRoleID Left Join
  hec_cmt_groupsubscriptions On hec_cmt_groupsubscriptions.Membership_RefID =
    hec_cmt_groupsubscription_requests.Membership_RefID And
    hec_cmt_groupsubscriptions.CommunityGroup_RefID =
    hec_cmt_groupsubscription_requests.CommunityGroup_RefID And
    (hec_cmt_groupsubscriptions.IsDeleted Is Null Or
      hec_cmt_groupsubscriptions.IsDeleted = 0) Inner Join
  hec_cmt_memberships On hec_cmt_groupsubscription_requests.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID Inner Join
  cmn_bpt_businessparticipants On hec_cmt_memberships.BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_usr_users On hec_cmt_memberships.BusinessParticipant_RefID =
    cmn_bpt_usr_users.BusinessParticipant_RefID
Where
  hec_cmt_groupsubscription_requests.CommunityGroup_RefID = @GroupIDs And
  hec_cmt_groupsubscription_requests.IsRejected = 0 And
  hec_cmt_groupsubscription_requests.IsApproved = 0 And
  hec_cmt_groupsubscription_requests.IsDeleted = 0 And
  hec_cmt_offeredroles_2_groupsubscriptionrequest.IsDeleted = 0 And
  hec_cmt_groupsubscription_requests.Tenant_RefID = @TenantID
  