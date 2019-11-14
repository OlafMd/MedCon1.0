
Select
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID As MeasurementRunID,
  mrs_run_measurementrun_statushistory.Creation_Timestamp As StatusChangedOn,
  mrs_run_measurementrun_statuses.GlobalPropertyMatchingID As StatusGlobalID,
  mrs_run_measurementrun_statuses.StatusDisplayName As StatusName,
  Count(Distinct mrs_run_measurements.MRS_RUN_MeasurementID) As MeasuredCount,
  Count(Distinct mrs_run_measurements1.MRS_RUN_MeasurementID) As
  NotMeasuredCount,
  mrs_run_measurementrun_statushistory.MRS_RUN_MeasurementRun_StatusHistoryID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_bpt_businessparticipants.DisplayName As StatusChangedBy
From
  mrs_run_measurementrun Left Join
  mrs_run_measurementrun_statushistory
    On mrs_run_measurementrun.MRS_RUN_MeasurementRunID =
    mrs_run_measurementrun_statushistory.MeasurementRun_RefID And
    mrs_run_measurementrun_statushistory.IsDeleted = 0 Inner Join
  mrs_run_measurementrun_statuses
    On mrs_run_measurementrun_statushistory.MeasurementRun_Status_RefID =
    mrs_run_measurementrun_statuses.MRS_RUN_MeasurementRun_StatusID And
    mrs_run_measurementrun_statuses.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On
    mrs_run_measurementrun_statushistory.TriggeredBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  mrs_run_measurements On mrs_run_measurements.MeasurementRun_RefID =
    mrs_run_measurementrun.MRS_RUN_MeasurementRunID And
    (mrs_run_measurements.IsMeasured = 1 Or mrs_run_measurements.IsMeasured Is
      Null) And (mrs_run_measurements.IsDeleted = 0 Or
      mrs_run_measurements.IsDeleted Is Null) Left Join
  mrs_run_measurements mrs_run_measurements1
    On mrs_run_measurements1.MeasurementRun_RefID =
    mrs_run_measurementrun.MRS_RUN_MeasurementRunID And
    (mrs_run_measurements1.IsMeasured = 0 Or mrs_run_measurements1.IsMeasured Is
      Null) And (mrs_run_measurements1.IsDeleted = 0 Or
      mrs_run_measurements1.IsDeleted Is Null) Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
Where
  mrs_run_measurementrun.IsDeleted = 0 And
  mrs_run_measurementrun.Tenant_RefID = @TenantID
Group By
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID,
  mrs_run_measurementrun_statushistory.MRS_RUN_MeasurementRun_StatusHistoryID
  
  