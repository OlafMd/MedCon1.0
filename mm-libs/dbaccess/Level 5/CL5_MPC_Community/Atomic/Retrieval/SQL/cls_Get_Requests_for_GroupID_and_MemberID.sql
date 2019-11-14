
Select
  hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID,
  hec_cmt_offeredroles.GlobalPropertyMatchingID As
  Role_GlobalPropertyMatchingID
From
  hec_cmt_groupsubscription_requests Inner Join
  hec_cmt_offeredroles_2_groupsubscriptionrequest
    On
    hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_GroupSubscription_Request_RefID = hec_cmt_groupsubscription_requests.HEC_CMT_GroupSubscription_RequestID Inner Join
  hec_cmt_offeredroles
    On hec_cmt_offeredroles_2_groupsubscriptionrequest.HEC_CMT_OfferedRole_RefID
    = hec_cmt_offeredroles.HEC_CMT_OfferedRoleID
Where
  hec_cmt_groupsubscription_requests.CommunityGroup_RefID = @GroupID And
  hec_cmt_groupsubscription_requests.IsRejected = 0 And
  hec_cmt_groupsubscription_requests.IsApproved = 0 And
  hec_cmt_groupsubscription_requests.IsDeleted = 0 And
  hec_cmt_groupsubscription_requests.Tenant_RefID = @TenantID And
  hec_cmt_offeredroles_2_groupsubscriptionrequest.IsDeleted = 0 And
  hec_cmt_groupsubscription_requests.Membership_RefID = @MemberID
  