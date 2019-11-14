
Select Distinct
  mrs_rut_routecycles.MRS_RUT_RouteCycleID,
  mrs_rut_routecycles.Route_RefID,
  mrs_rut_routecycles.ValidFrom,
  mrs_rut_routecycles.ValidThrough,
  mrs_rut_routecycles.CronExpressions,
  mrs_rut_routecycles.Creation_Timestamp,
  mrs_rut_routecycles.Tenant_RefID,
  mrs_rut_routecycles.IsDeleted
From
  mrs_run_measurementrun_accountdownloadcodes Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID Inner Join
  mrs_rut_routes On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_run_measurementrun_routes.Route_RefID Inner Join
  mrs_rut_routecycles On mrs_rut_routecycles.Route_RefID =
    mrs_rut_routes.MRS_RUT_RouteID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID
Where
  mrs_rut_routecycles.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode
  