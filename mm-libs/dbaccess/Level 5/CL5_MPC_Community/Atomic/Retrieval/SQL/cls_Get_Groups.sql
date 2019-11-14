
    Select
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID,
  hec_cmt_communitygroups.CommunityGroup_Name_DictID,
  hec_cmt_communitygroups.IsPrivate,
  hec_cmt_communitygroups.CommunityGroupCode,
  hec_cmt_communitygroups.HealthcareCommunityGroupITL,
  hec_cmt_communitygroups.CommunityGroup_Description_DictID
From
  hec_cmt_communities Inner Join
  hec_cmt_communitygroups On hec_cmt_communities.HEC_CMT_CommunityID =
    hec_cmt_communitygroups.Community_RefID
Where
  hec_cmt_communitygroups.IsPrivate = 0 And
  hec_cmt_communities.IsDeleted = 0 And
  hec_cmt_communitygroups.IsDeleted = 0 and
  hec_cmt_communitygroups.Tenant_RefID = @TenantID 
  