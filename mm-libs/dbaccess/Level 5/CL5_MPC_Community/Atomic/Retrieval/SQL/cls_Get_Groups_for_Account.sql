
Select
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID,
  hec_cmt_communitygroups.CommunityGroup_Name_DictID,
  hec_cmt_communitygroups.IsPrivate,
  hec_cmt_communitygroups.CommunityGroupCode,
  hec_cmt_communitygroups.HealthcareCommunityGroupITL
From
  hec_cmt_communitygroups Inner Join
  hec_cmt_groupsubscriptions On hec_cmt_groupsubscriptions.CommunityGroup_RefID
    = hec_cmt_communitygroups.Community_RefID Inner Join
  hec_cmt_memberships On hec_cmt_groupsubscriptions.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    hec_cmt_memberships.BusinessParticipant_RefID
Where
  hec_cmt_communitygroups.IsPrivate = 0 And
  hec_cmt_communitygroups.Tenant_RefID = @TenantID And
  usr_accounts.USR_AccountID = @AccountID And
  hec_cmt_memberships.IsDeleted = 0 And
  hec_cmt_groupsubscriptions.IsDeleted = 0 And
  hec_cmt_communitygroups.IsDeleted = 0
  