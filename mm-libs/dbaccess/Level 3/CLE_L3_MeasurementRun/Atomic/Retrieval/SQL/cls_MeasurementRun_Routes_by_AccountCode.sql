
Select Distinct
  mrs_run_measurementrun_routes.MRS_RUN_MeasurementRun_RouteID,
  mrs_run_measurementrun_routes.IsDeleted,
  mrs_run_measurementrun_routes.Route_RefID,
  mrs_run_measurementrun_routes.MeasurementRun_RefID,
  mrs_run_measurementrun_routes.BoundTo_Account_RefID,
  mrs_run_measurementrun_routes.Creation_Timestamp,
  mrs_run_measurementrun_routes.Tenant_RefID
From
  mrs_run_measurementrun_accountdownloadcodes Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On
    cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID = mrs_run_measurementrun_accountdownloadcodes.Account_RefID
Where
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode
  