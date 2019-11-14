Select Distinct
  mrs_mpt_addresshistory.MRS_MPT_AddressHistoryID,
  mrs_mpt_addresshistory.MeasuringPoint_RefID,
  mrs_mpt_addresshistory.Address_RefID,
  mrs_mpt_addresshistory.ActiveFrom,
  mrs_mpt_addresshistory.ActiveThrough,
  mrs_mpt_addresshistory.Creation_Timestamp,
  mrs_mpt_addresshistory.Tenant_RefID,
  mrs_mpt_addresshistory.IsDeleted
From
  usr_device_accountcodes Inner Join
  mrs_run_measurementrun_accountdownloadcodes
    On usr_device_accountcodes.Account_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID And
    mrs_run_measurementrun_routes.BoundTo_Account_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  mrs_rut_routes On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_run_measurementrun_routes.Route_RefID Inner Join
  mrs_rut_route_measuringpoints On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_rut_route_measuringpoints.Route_RefID Inner Join
  mrs_mpt_measuringpoints On mrs_rut_route_measuringpoints.MeasuringPoint_RefID
    = mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID Inner Join
  mrs_mpt_addresshistory On mrs_mpt_addresshistory.MeasuringPoint_RefID =
    mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID
Where
  mrs_mpt_addresshistory.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @AccountCode And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode