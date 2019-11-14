

Select
  hec_cmt_memberships.HEC_CMT_MembershipID,
  hec_cmt_community_offeredmembershiptypes.IsAvailableFor_Tenants,
  hec_cmt_community_offeredmembershiptypes.IsAvailableFor_Doctors,
  hec_cmt_offeredroles.GlobalPropertyMatchingID,
  hec_cmt_offeredroles.HEC_CMT_OfferedRoleID,
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID
From
  cmn_bpt_usr_users Inner Join
  hec_cmt_memberships On cmn_bpt_usr_users.BusinessParticipant_RefID =
    hec_cmt_memberships.BusinessParticipant_RefID Inner Join
  hec_cmt_community_offeredmembershiptypes
    On
    hec_cmt_community_offeredmembershiptypes.HEC_CMT_Community_OfferedMembershipTypeID = hec_cmt_memberships.MembershipType_RefID Left Join
  hec_cmt_groupsubscriptions On hec_cmt_groupsubscriptions.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID And
    (hec_cmt_groupsubscriptions.IsDeleted Is Null Or
      hec_cmt_groupsubscriptions.IsDeleted = 0) Left Join
  hec_cmt_communitygroups On hec_cmt_groupsubscriptions.CommunityGroup_RefID =
    hec_cmt_communitygroups.HEC_CMT_CommunityGroupID And
    (hec_cmt_communitygroups.IsDeleted Is Null Or
      hec_cmt_communitygroups.IsDeleted = 0) Left Join
  hec_cmt_offeredroles_2_groupsubscription
    On hec_cmt_offeredroles_2_groupsubscription.HEC_CMT_GroupSubscription_RefID
    =
    hec_cmt_groupsubscriptions.HEC_CMT_GroupSubscriptionID and 
    (hec_cmt_offeredroles_2_groupsubscription.IsDeleted Is Null Or hec_cmt_offeredroles_2_groupsubscription.IsDeleted = 0) Left Join
  hec_cmt_offeredroles On hec_cmt_offeredroles.HEC_CMT_OfferedRoleID =
    hec_cmt_offeredroles_2_groupsubscription.HEC_CMT_OfferedRole_RefID
    And (hec_cmt_offeredroles.IsDeleted Is Null Or
      hec_cmt_offeredroles.IsDeleted = 0)
Where
  cmn_bpt_usr_users.IsDeleted = 0 And
  cmn_bpt_usr_users.CMN_BPT_USR_UserID = @CMN_BPT_USR_UserID And
  hec_cmt_memberships.IsDeleted = 0
  