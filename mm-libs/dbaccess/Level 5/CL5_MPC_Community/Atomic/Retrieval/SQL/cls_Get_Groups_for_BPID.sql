
Select
  hec_cmt_communitygroups.HEC_CMT_CommunityGroupID,
  hec_cmt_communitygroups.CommunityGroup_Name_DictID,
  hec_cmt_communitygroups.IsPrivate,
  hec_cmt_communitygroups.CommunityGroupCode,
  hec_cmt_communitygroups.HealthcareCommunityGroupITL,
  hec_cmt_communitygroups.CommunityGroup_Description_DictID,
  hec_cmt_offeredroles.GlobalPropertyMatchingID As Role_GlobalPropertyMatchingID,
  hec_cmt_offeredroles_2_groupsubscription.AssignmentID,
  hec_cmt_offeredroles.HEC_CMT_OfferedRoleID As Role_HEC_CMT_OfferedRoleID,
  hec_cmt_offeredroles1.GlobalPropertyMatchingID As Request_GlobalPropertyMatchingID,
  hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID,
  hec_cmt_offeredroles1.HEC_CMT_OfferedRoleID As Request_HEC_CMT_OfferedRoleID
From
  hec_cmt_communitygroups Inner Join
  hec_cmt_groupsubscriptions On hec_cmt_groupsubscriptions.CommunityGroup_RefID
    = hec_cmt_communitygroups.HEC_CMT_CommunityGroupID Inner Join
  hec_cmt_memberships On hec_cmt_groupsubscriptions.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID Inner Join
  hec_cmt_offeredroles_2_groupsubscription
    On hec_cmt_offeredroles_2_groupsubscription.HEC_CMT_GroupSubscription_RefID
    = hec_cmt_groupsubscriptions.HEC_CMT_GroupSubscriptionID Inner Join
  hec_cmt_offeredroles
    On hec_cmt_offeredroles_2_groupsubscription.HEC_CMT_OfferedRole_RefID =
    hec_cmt_offeredroles.HEC_CMT_OfferedRoleID Left Join
  hec_cmt_groupsubscription_requests
    On hec_cmt_groupsubscription_requests.CommunityGroup_RefID =
    hec_cmt_groupsubscriptions.CommunityGroup_RefID And
    hec_cmt_groupsubscription_requests.Membership_RefID =
    hec_cmt_groupsubscriptions.Membership_RefID and
    (hec_cmt_groupsubscription_requests.IsApproved is null or hec_cmt_groupsubscription_requests.IsApproved = 0) and
    (hec_cmt_groupsubscription_requests.IsRejected is null or hec_cmt_groupsubscription_requests.IsRejected = 0) and
    (hec_cmt_groupsubscription_requests.IsDeleted is null or hec_cmt_groupsubscription_requests.IsDeleted = 0) Left Join
  hec_cmt_offeredroles_2_groupsubscriptionrequest
    On
    hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_GroupSubscription_Request_RefID = hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID
    and (hec_cmt_offeredroles_2_groupsubscriptionrequest.IsDeleted is null or hec_cmt_offeredroles_2_groupsubscriptionrequest.IsDeleted = 0 ) Left Join
  hec_cmt_offeredroles hec_cmt_offeredroles1
    On hec_cmt_offeredroles1.HEC_CMT_OfferedRoleID =
    hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_OfferedRole_RefID
    and (hec_cmt_offeredroles1.IsDeleted = 0 or hec_cmt_offeredroles1.IsDeleted is null)
Where
  hec_cmt_memberships.Tenant_RefID = @TenantID And
  hec_cmt_memberships.IsDeleted = 0 And
  hec_cmt_groupsubscriptions.IsDeleted = 0 And
  hec_cmt_communitygroups.IsDeleted = 0 And
  hec_cmt_memberships.BusinessParticipant_RefID = @BPID And
  hec_cmt_offeredroles.IsDeleted = 0 and
  hec_cmt_offeredroles_2_groupsubscription.IsDeleted = 0

  