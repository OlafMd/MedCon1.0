
Select
  cmn_tenants.TenantITL,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_businessparticipants.BusinessParticipantITL,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  TrustRelation.CMN_TRL_TrustRelationID,
  TrustRelation.CMN_TRL_TrustRelationRequestID,
  TrustRelation.TrustRelationRequestITL
From
  cmn_tenants Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfTenant_Tenant_RefID =
    cmn_tenants.CMN_TenantID Left Join
  (Select
    cmn_trl_trustrelation.CMN_TRL_TrustRelationID,
    cmn_trl_trustrelation.CMN_BPT_BusinessParticpant_RefID,
    cmn_trl_trustrelationrequests.IsApproved,
    cmn_trl_trustrelationrequests.IsRejected,
    cmn_trl_trustrelationrequests.CMN_TRL_TrustRelationRequestID,
    cmn_trl_trustrelationrequests.TrustRelationRequestITL
  From
    cmn_trl_trustrelation Inner Join
    cmn_trl_trustrelation_types
      On cmn_trl_trustrelation.CMN_TRL_TrustRelation_Type_RefID =
      cmn_trl_trustrelation_types.CMN_TRL_TrustRelation_TypeID Inner Join
    cmn_trl_trustrelationrequests
      On cmn_trl_trustrelationrequests.CMN_TRL_TrustRelationRequestID =
      cmn_trl_trustrelation.CreatedFrom_TrustRelationRequest_RefID
  Where
    cmn_trl_trustrelationrequests.IsApproved = 1 And
    cmn_trl_trustrelationrequests.IsRejected = 0 And
    cmn_trl_trustrelation.IsDeleted = 0 And
    cmn_trl_trustrelation_types.IsDeleted = 0 And
    cmn_trl_trustrelation.Tenant_RefID = @TenantID And
    cmn_trl_trustrelation.IsValid = 1 And
    cmn_trl_trustrelation.IsPaused = 0 And
    cmn_trl_trustrelation_types.TrustRelationTypeITL = @TypeITL) TrustRelation
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    TrustRelation.CMN_BPT_BusinessParticpant_RefID
Where
  cmn_tenants.CMN_TenantID != cmn_tenants.Tenant_RefID And
  cmn_tenants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 1 And
  cmn_tenants.Tenant_RefID = @TenantID
  