Select Distinct
  mrs_run_measurement_expectedvalues.MRS_RUN_Measurement_ExpectedValueID,
  mrs_run_measurement_expectedvalues.MRS_RUN_Measurement_RefID,
  mrs_run_measurement_expectedvalues.ExpectedValueMax,
  mrs_run_measurement_expectedvalues.ExpectedValueMin,
  mrs_run_measurement_expectedvalues.MeasurementTariff_RefID,
  mrs_run_measurement_expectedvalues.Creation_Timestamp,
  mrs_run_measurement_expectedvalues.Tenant_RefID,
  mrs_run_measurement_expectedvalues.IsDeleted
From
  mrs_run_measurementrun_accountdownloadcodes Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID And
    mrs_run_measurementrun_routes.BoundTo_Account_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  mrs_rut_routes On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_run_measurementrun_routes.Route_RefID Inner Join
  mrs_rut_route_measuringpoints On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_rut_route_measuringpoints.Route_RefID Inner Join
  mrs_run_measurements
    On mrs_rut_route_measuringpoints.MRS_RUT_Route_MeasuringPointID =
    mrs_run_measurements.MeasuringPoint_RefID And
    mrs_run_measurements.MeasurementRun_RefID =
    mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID Inner Join
  mrs_run_measurement_expectedvalues
    On mrs_run_measurement_expectedvalues.MRS_RUN_Measurement_RefID =
    mrs_run_measurements.MRS_RUN_MeasurementID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On mrs_run_measurementrun_accountdownloadcodes.Account_RefID =
    cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID
Where
  mrs_run_measurement_expectedvalues.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_run_measurements.IsMeasured = 0 And
  mrs_run_measurements.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode