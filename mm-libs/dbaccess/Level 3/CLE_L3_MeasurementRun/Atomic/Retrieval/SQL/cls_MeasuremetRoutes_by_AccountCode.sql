
Select Distinct
  mrs_rut_routes.MRS_RUT_RouteID,
  mrs_rut_routes.DisplayName,
  mrs_rut_routes.Creation_Timestamp,
  mrs_rut_routes.Tenant_RefID,
  mrs_rut_routes.IsDeleted,
  mrs_rut_routes.IsTemporaryRoute,
  mrs_rut_routes.Default_RouteReaderAccount_RefID
From
  mrs_run_measurementrun_accountdownloadcodes Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_routes.MeasurementRun_RefID =
    mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID Inner Join
  mrs_rut_routes On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_run_measurementrun_routes.Route_RefID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID
Where
  mrs_rut_routes.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode
  