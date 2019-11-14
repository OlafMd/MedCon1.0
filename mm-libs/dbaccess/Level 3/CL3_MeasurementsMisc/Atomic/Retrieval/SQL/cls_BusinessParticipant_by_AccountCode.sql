
	Select
  DISTINCT cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_bpt_businessparticipants.IsNaturalPerson,
  cmn_bpt_businessparticipants.IsCompany,
  cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID,
  cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
  cmn_bpt_businessparticipants.IsTenant,
  cmn_bpt_businessparticipants.IfTenant_Tenant_RefID,
  cmn_bpt_businessparticipants.Creation_Timestamp,
  cmn_bpt_businessparticipants.IsDeleted,
  cmn_bpt_businessparticipants.Tenant_RefID,
  cmn_bpt_businessparticipants.DisplayImage_RefID,
  cmn_bpt_businessparticipants.DefaultLanguage_RefID,
  cmn_bpt_businessparticipants.DefaultCurrency_RefID,
  cmn_bpt_businessparticipants.LastContacted_Date,
  cmn_bpt_businessparticipants.LastContacted_ByBusinessPartner_RefID,
  cmn_bpt_businessparticipants.Audit_UpdatedByAccount_RefID,
  cmn_bpt_businessparticipants.Audit_UpdatedOn,
  cmn_bpt_businessparticipants.Audit_CreatedByAccount_RefID,
  cmn_bpt_businessparticipants.BusinessParticipantITL
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
    cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID
Where
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @AccountCode And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_mpt_customerownerships.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode
  