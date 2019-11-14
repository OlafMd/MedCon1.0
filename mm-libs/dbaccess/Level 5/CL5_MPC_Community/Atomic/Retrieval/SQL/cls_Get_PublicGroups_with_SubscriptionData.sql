
Select
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID,
  hec_cmt_communitygroups.CommunityGroup_Name_DictID,
  hec_cmt_communitygroups.IsPrivate,
  hec_cmt_communitygroups.CommunityGroupCode,
  hec_cmt_communitygroups.HealthcareCommunityGroupITL,
  hec_cmt_communitygroups.CommunityGroup_Description_DictID,
  hec_cmt_groupsubscriptions.HEC_CMT_GroupSubscriptionID,
  hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID
From
  hec_cmt_communities Inner Join
  hec_cmt_communitygroups On hec_cmt_communities.HEC_CMT_CommunityID =
    hec_cmt_communitygroups.Community_RefID Left Join
  hec_cmt_groupsubscriptions On hec_cmt_communitygroups.HEC_CMT_CommunityGroupID
    = hec_cmt_groupsubscriptions.CommunityGroup_RefID And
    (hec_cmt_groupsubscriptions.IsDeleted Is Null Or
      hec_cmt_groupsubscriptions.IsDeleted = 0) And
    (hec_cmt_groupsubscriptions.Membership_RefID = @MemberID Or
      hec_cmt_groupsubscriptions.Membership_RefID Is Null) Left Join
  hec_cmt_groupsubscription_requests
    On hec_cmt_communitygroups.HEC_CMT_CommunityGroupID =
    hec_cmt_groupsubscription_requests.CommunityGroup_RefID And
    (hec_cmt_groupsubscription_requests.IsDeleted Is Null Or
      hec_cmt_groupsubscription_requests.IsDeleted = 0) And
    (hec_cmt_groupsubscription_requests.Membership_RefID Is Null Or
      hec_cmt_groupsubscription_requests.Membership_RefID = @MemberID)
    And (hec_cmt_groupsubscription_requests.IsRejected = 0 Or
      hec_cmt_groupsubscription_requests.IsRejected Is Null) And
    (hec_cmt_groupsubscription_requests.IsApproved = 0 Or
      hec_cmt_groupsubscription_requests.IsApproved Is Null)
Where
  hec_cmt_communitygroups.IsPrivate = 0 And
  hec_cmt_communitygroups.IsDeleted = 0 And
  hec_cmt_communities.IsDeleted = 0 And
  hec_cmt_communitygroups.Tenant_RefID = @TenantID
  