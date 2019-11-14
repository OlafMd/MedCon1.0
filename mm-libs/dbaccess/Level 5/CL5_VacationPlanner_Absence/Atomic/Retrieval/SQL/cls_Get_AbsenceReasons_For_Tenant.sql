
Select
  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID,
  cmn_bpt_sta_absencereasons.ShortName,
  cmn_bpt_sta_absencereasons.Name_DictID,
  cmn_bpt_sta_absencereasons.Description_DictID,
  cmn_bpt_sta_absencereasons.ColorCode,
  cmn_bpt_sta_absencereasons.Parent_RefID,
  cmn_bpt_sta_absencereasons.IsAuthorizationRequired,
  cmn_bpt_sta_absencereasons.IsIncludedInCapacityCalculation,
  cmn_bpt_sta_absencereasons.IsAllowedAbsence,
  cmn_bpt_sta_absencereasons.IsCarryOverEnabled,
  cmn_bpt_sta_absencereasons.IsDeactivated,
  cmn_bpt_sta_absencereasons.Creation_Timestamp,
  cmn_bpt_sta_absencereasons.IsLeaveTimeReducing_WorkingHours,
  cmn_bpt_sta_absencereasons.IsLeaveTimeReducing_OverHours As
  IsLeaveTimeReducingOverTime
From
  cmn_bpt_sta_absencereasons
Where
  cmn_bpt_sta_absencereasons.Tenant_RefID = @TenantID And
  cmn_bpt_sta_absencereasons.IsDeleted = 0
  