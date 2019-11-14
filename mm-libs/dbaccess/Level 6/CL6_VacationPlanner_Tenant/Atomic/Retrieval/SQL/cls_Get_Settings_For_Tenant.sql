
Select
  cmn_cal_apr_responsiblepersons.NumberOfResponsiblePersonsRequiredToApprove,
  cmn_cal_apr_responsiblepersons.CMN_CAL_APR_ResponsiblePersonID,
  cmn_tenants.IsUsing_Offices,
  cmn_tenants.IsUsing_WorkAreas,
  cmn_tenants.IsUsing_Workplaces,
  cmn_tenants.IsUsing_CostCenters,
  cmn_cal_event_approvalprocess_types.CMN_CAL_Event_ApprovalProcess_TypeID,
  cmn_tenant_activeapprovalprocesstypes.CMN_Tenant_ActiveApprovalProcessTypeID
From
  cmn_cal_apr_responsiblepersons Inner Join
  cmn_cal_event_approvalprocess_types
    On cmn_cal_event_approvalprocess_types.IfResponsiblePersonBased_RefID =
    cmn_cal_apr_responsiblepersons.CMN_CAL_APR_ResponsiblePersonID Inner Join
  cmn_tenant_activeapprovalprocesstypes
    On
    cmn_tenant_activeapprovalprocesstypes.CMN_CAL_Event_ApprovalProcess_Type_RefID = cmn_cal_event_approvalprocess_types.CMN_CAL_Event_ApprovalProcess_TypeID Inner Join
  cmn_tenants
    On cmn_tenants.CMN_TenantID =
    cmn_tenant_activeapprovalprocesstypes.Tenant_RefID
Where
  cmn_cal_apr_responsiblepersons.IsDeleted = 0 And
  cmn_tenants.IsDeleted = 0 And
  cmn_tenant_activeapprovalprocesstypes.IsActive = 1 And
  cmn_tenant_activeapprovalprocesstypes.IsDeleted = 0 And
  cmn_cal_event_approvalprocess_types.IsDeleted = 0 And
  cmn_cal_event_approvalprocess_types.IsResponsiblePersonBased = 1 And
  cmn_tenants.CMN_TenantID = @TenantID
  