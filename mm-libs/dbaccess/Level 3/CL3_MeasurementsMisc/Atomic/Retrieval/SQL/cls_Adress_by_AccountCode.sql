
	Select
	DISTINCT cmn_addresses.CMN_AddressID,
  cmn_addresses.Longitude,
  cmn_addresses.Lattitude,
  cmn_addresses.CareOf,
  cmn_addresses.Province_EconomicRegion_RefID,
  cmn_addresses.Tenant_RefID,
  cmn_addresses.IsDeleted,
  cmn_addresses.Creation_Timestamp,
  cmn_addresses.Country_ISOCode,
  cmn_addresses.Country_Name,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Province_Name,
  cmn_addresses.City_Region,
  cmn_addresses.City_AdministrativeDistrict,
  cmn_addresses.Street_Number,
  cmn_addresses.Street_Name
  
From
  usr_device_accountcodes Inner Join
  mrs_run_measurementrun_accountdownloadcodes
    On usr_device_accountcodes.Account_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID Inner Join
  mrs_rut_routes On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_run_measurementrun_routes.Route_RefID Inner Join
  mrs_rut_route_measuringpoints On mrs_rut_routes.MRS_RUT_RouteID =
    mrs_rut_route_measuringpoints.Route_RefID Inner Join
  mrs_mpt_measuringpoints On mrs_rut_route_measuringpoints.MeasuringPoint_RefID
    = mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID Inner Join
  cmn_addresses On mrs_mpt_measuringpoints.CurrentAddress_RefID =
    cmn_addresses.CMN_AddressID
Where
  cmn_addresses.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @AccountCode And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0
  