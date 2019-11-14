
	Select
	DISTINCT cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
  cmn_bpt_ctm_customers.CustomerOrderDefaultShipmentWarehouse_RefID,
  cmn_bpt_ctm_customers.InternalCustomerNumber,
  cmn_bpt_ctm_customers.Tenant_RefID,
  cmn_bpt_ctm_customers.IsDeleted,
  cmn_bpt_ctm_customers.Creation_Timestamp,
  cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID,
  cmn_bpt_ctm_customers.CustomerAffinityStatus_RefID
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
  mrs_mpt_customerownerships On mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID
    = mrs_mpt_customerownerships.MeasuringPoint_RefID Inner Join
  cmn_bpt_ctm_customers On mrs_mpt_customerownerships.Customer_RefID =
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID
Where
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @AccountCode And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_mpt_customerownerships.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0
  