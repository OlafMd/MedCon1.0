
	Select
  DISTINCT cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.ProfileImage_Document_RefID,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Address_RefID,
  cmn_per_personinfo.Creation_Timestamp,
  cmn_per_personinfo.IsDeleted,
  cmn_per_personinfo.Tenant_RefID,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.NumberOfChildren,
  cmn_per_personinfo.IsRepresentedByLegalGuardian
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
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  cmn_per_personinfo.IsDeleted = 0 And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  usr_device_accountcodes.AccountCode_Value = @AccountCode And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_mpt_customerownerships.IsDeleted = 0 And
  cmn_bpt_ctm_customers.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode
  