
Select
  mrs_run_measurements.MRS_RUN_MeasurementID As MeasurementID,
  mrs_mpt_meters.SerialNumber As MeterSerialNumber,
  mrs_mpt_customerownerships.ContractNumber,
  drv_customers.FirstName As OwnerFirstName,
  drv_customers.LastName As OwnerLastName,
  cmn_addresses.Street_Name As StreetName,
  cmn_addresses.Street_Number As StreetNumber,
  cmn_addresses.City_Name As City,
  mrs_rut_routes.DisplayName As RouteName,
  mrs_rut_route_measuringpoints.OrderSequence As SequenceInRoute,
  mrs_rut_routes.MRS_RUT_RouteID,
  mrs_run_measurement_values.MeasuredAt_Time,
  mrs_run_measurement_values.MRS_RUN_Measurement_ValueID,
  mrs_run_measurementrun_routes.MRS_RUN_MeasurementRun_RouteID,
  mrs_run_measurementrun_routes.BoundTo_Account_RefID,
  mrs_run_measurement_tariffs.MRS_RUN_Measurement_TariffID,
  mrs_run_measurement_tariffs.MeasurementTariffName_DictID,
  mrs_run_measurement_tariffs.GlobalPropertyMatchingID As
  Tariff_GlobalPropertyMatchingID,
  mrs_run_measurement_values.MeasurementValue,
  cmn_addresses.City_PostalCode,
  mrs_run_measurement_valueacquisitiontypes.GlobalPropertyMatchingID as AcqusitionTypeGPM
From
  mrs_run_measurements Inner Join
  mrs_rut_route_measuringpoints On mrs_run_measurements.MeasuringPoint_RefID =
    mrs_rut_route_measuringpoints.MRS_RUT_Route_MeasuringPointID And
    mrs_rut_route_measuringpoints.IsDeleted = 0 And
    mrs_rut_route_measuringpoints.Tenant_RefID = @TenantID Inner Join
  mrs_rut_routes On mrs_rut_route_measuringpoints.Route_RefID =
    mrs_rut_routes.MRS_RUT_RouteID And mrs_rut_routes.IsDeleted = 0 And
    mrs_rut_routes.Tenant_RefID = @TenantID Inner Join
  mrs_mpt_measuringpoints On mrs_rut_route_measuringpoints.MeasuringPoint_RefID
    = mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID And
    mrs_mpt_measuringpoints.IsDeleted = 0 And
    mrs_mpt_measuringpoints.Tenant_RefID = @TenantID Inner Join
  cmn_addresses On mrs_mpt_measuringpoints.CurrentAddress_RefID =
    cmn_addresses.CMN_AddressID And cmn_addresses.IsDeleted = 0 And
    cmn_addresses.Tenant_RefID = @TenantID Inner Join
  mrs_mpt_measuringpoint_meterbindings
    On mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID =
    mrs_mpt_measuringpoint_meterbindings.MeasuringPoint_RefID And
    mrs_mpt_measuringpoint_meterbindings.IsDeleted = 0 And
    mrs_mpt_measuringpoint_meterbindings.Tenant_RefID = @TenantID Inner Join
  mrs_mpt_meters On mrs_mpt_measuringpoint_meterbindings.Meter_RefID =
    mrs_mpt_meters.MRS_MPT_MeterID And mrs_mpt_meters.IsDeleted = 0 And
    mrs_mpt_meters.Tenant_RefID = @TenantID Inner Join
  mrs_mpt_customerownerships On mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID
    = mrs_mpt_customerownerships.MeasuringPoint_RefID And
    mrs_mpt_customerownerships.IsDeleted = 0 And
    mrs_mpt_customerownerships.Tenant_RefID = @TenantID Inner Join
  (Select
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName
  From
    cmn_bpt_ctm_customers Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
      cmn_bpt_businessparticipants.IsDeleted = 0 And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
    cmn_per_personinfo
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted =
      0 And cmn_per_personinfo.Tenant_RefID = @TenantID
  Where
    cmn_bpt_ctm_customers.IsDeleted = 0 And
    cmn_bpt_ctm_customers.Tenant_RefID = @TenantID) drv_customers
    On mrs_mpt_customerownerships.Customer_RefID =
    drv_customers.CMN_BPT_CTM_CustomerID Inner Join
  mrs_run_measurementrun On mrs_run_measurementrun.MRS_RUN_MeasurementRunID =
    mrs_run_measurements.MeasurementRun_RefID Left Join
  mrs_run_measurement_values On mrs_run_measurements.MRS_RUN_MeasurementID =
    mrs_run_measurement_values.Measurement_RefID And
    (mrs_run_measurement_values.IsDeleted Is Null Or
      mrs_run_measurement_values.IsDeleted = 0) Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun.MRS_RUN_MeasurementRunID =
    mrs_run_measurementrun_routes.MeasurementRun_RefID And
    mrs_rut_routes.MRS_RUT_RouteID = mrs_run_measurementrun_routes.Route_RefID
  Left Join
  mrs_run_measurement_tariffs
    On mrs_run_measurement_values.MeasurementTariff_RefID =
    mrs_run_measurement_tariffs.MRS_RUN_Measurement_TariffID And
    (mrs_run_measurement_tariffs.IsDeleted Is Null Or
      mrs_run_measurement_tariffs.IsDeleted = 0) Left Join
  mrs_run_measurement_valueacquisitiontypes
    On
    mrs_run_measurement_valueacquisitiontypes.MRS_RUN_Measurement_ValueAcquisitionTypeID = mrs_run_measurement_values.Measurement_AcquisitionType_RefID
Where
  mrs_run_measurements.Tenant_RefID = @TenantID And
  mrs_run_measurements.IsDeleted = 0 And
  mrs_run_measurementrun.MRS_RUN_MeasurementRunID = @ReadingSessionId And
  mrs_run_measurementrun_routes.IsDeleted = 0
  
  