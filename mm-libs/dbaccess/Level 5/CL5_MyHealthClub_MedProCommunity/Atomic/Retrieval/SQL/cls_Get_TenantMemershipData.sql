
Select
  hec_cmt_membership_credentials.Membership_Username,
  hec_cmt_membership_credentials.Membership_Password,
  hec_cmt_memberships.HEC_CMT_MembershipID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  hec_cmt_membership_credentials.HEC_CMT_Membership_CredentialID
From
  cmn_bpt_businessparticipants Left Join
  hec_cmt_memberships On hec_cmt_memberships.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    (hec_cmt_memberships.IsDeleted Is Null Or hec_cmt_memberships.IsDeleted = 0)
  Left Join
  hec_cmt_membership_credentials
    On hec_cmt_membership_credentials.Membership_RefID =
    hec_cmt_memberships.HEC_CMT_MembershipID And
    (hec_cmt_membership_credentials.IsDeleted Is Null Or
      hec_cmt_membership_credentials.IsDeleted = 0)
Where
  cmn_bpt_businessparticipants.IsTenant = 1 And
  cmn_bpt_businessparticipants.IfTenant_Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  