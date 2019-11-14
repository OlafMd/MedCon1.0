Select
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID As MeasurementRunID,
  mrs_run_measurementrun_statuses.GlobalPropertyMatchingID As StatusGlobalID,
  mrs_run_measurementrun_statuses.StatusDisplayName As StatusName,
  mrs_run_measurementrun_statushistory.Creation_Timestamp As StatusChangedOn,
  cmn_bpt_businessparticipants.DisplayName As StatusChangedBy
From
  mrs_run_measurementrun Left Join
  mrs_run_measurementrun_statushistory
    On mrs_run_measurementrun.MRS_RUN_MeasurementRunID =
    mrs_run_measurementrun_statushistory.MeasurementRun_RefID And
    mrs_run_measurementrun_statushistory.IsDeleted = 0 And
    mrs_run_measurementrun_statushistory.Tenant_RefID = @TenantID Inner Join
  mrs_run_measurementrun_statuses
    On mrs_run_measurementrun_statushistory.MeasurementRun_Status_RefID =
    mrs_run_measurementrun_statuses.MRS_RUN_MeasurementRun_StatusID And
    mrs_run_measurementrun_statuses.IsDeleted = 0 And
    mrs_run_measurementrun_statuses.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On mrs_run_measurementrun_statushistory.TriggeredBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
Where
  mrs_run_measurementrun.IsDeleted = 0 And
  mrs_run_measurementrun.Tenant_RefID = @TenantID And
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID = @ReadingSessionId