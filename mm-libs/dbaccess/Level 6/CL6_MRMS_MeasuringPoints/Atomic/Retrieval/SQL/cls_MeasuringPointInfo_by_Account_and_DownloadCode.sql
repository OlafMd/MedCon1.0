Select
  mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID,
  mrs_mpt_measuringpoints.ExternalMeasuringPointID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_per_personinfo.FirstName As OwnerFirstName,
  cmn_per_personinfo.LastName As OwnerLastName,
  mrs_mpt_meters.SerialNumber As MeterSerial,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Country_Name
From
  mrs_rut_route_measuringpoints Inner Join
  mrs_mpt_measuringpoints On mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID =
    mrs_rut_route_measuringpoints.MeasuringPoint_RefID Inner Join
  mrs_mpt_customerownerships On mrs_mpt_customerownerships.MeasuringPoint_RefID
    = mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID Inner Join
  cmn_bpt_ctm_customers On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
    mrs_mpt_customerownerships.Customer_RefID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  cmn_addresses On cmn_addresses.CMN_AddressID =
    mrs_mpt_measuringpoints.CurrentAddress_RefID Inner Join
  mrs_mpt_measuringpoint_meterbindings
    On mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID =
    mrs_mpt_measuringpoint_meterbindings.MeasuringPoint_RefID Inner Join
  mrs_mpt_meters On mrs_mpt_meters.MRS_MPT_MeterID =
    mrs_mpt_measuringpoint_meterbindings.Meter_RefID Inner Join
  mrs_run_measurementrun_routes On mrs_run_measurementrun_routes.Route_RefID =
    mrs_rut_route_measuringpoints.Route_RefID Inner Join
  mrs_run_measurementrun_accountdownloadcodes
    On mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID And
    mrs_run_measurementrun_routes.BoundTo_Account_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On cmn_bpt_businessparticipant_accesscodes.BusinessParticipant_RefID =
    mrs_run_measurementrun_accountdownloadcodes.Account_RefID Inner Join
  mrs_run_measurements On mrs_run_measurements.MeasuringPoint_RefID =
    mrs_rut_route_measuringpoints.MRS_RUT_Route_MeasuringPointID And
    mrs_run_measurementrun_accountdownloadcodes.MeasurementRun_RefID =
    mrs_run_measurements.MeasurementRun_RefID
Where
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode And
  mrs_run_measurements.IsDeleted = 0 And
  mrs_run_measurements.IsMeasured = 0
Group By
  mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID, cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode, cmn_addresses.Country_Name,
  cmn_bpt_businessparticipant_accesscodes.Code
Order By
  cmn_addresses.Street_Name Desc