
Select Distinct
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID,
  mrs_run_measurementrun.DateFrom,
  mrs_run_measurementrun.DateThrough,
  mrs_run_measurementrun.Creation_Timestamp,
  mrs_run_measurementrun.Tenant_RefID,
  mrs_run_measurementrun.IsDeleted,
  mrs_run_measurementrun.IsCorrectionRun,
  mrs_run_measurementrun.CorrectionOf_MeasurementRun_RefID
From
  mrs_run_measurementrun_accountdownloadcodes Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID Inner Join
  mrs_run_measurementrun On mrs_run_measurementrun.MRS_RUN_MeasurementRunID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On mrs_run_measurementrun_accountdownloadcodes.Account_RefID =
    cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID
Where
  mrs_run_measurementrun.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode
  