Select Distinct
  mrs_mpt_notes.MRS_MPT_NoteID,
  mrs_mpt_notes.MeasuringPoint_RefID,
  mrs_mpt_notes.IsDeleted,
  mrs_mpt_notes.Tenant_RefID,
  mrs_mpt_notes.Creation_Timestamp,
  mrs_mpt_notes.SequenceNumber,
  mrs_mpt_notes.CreatedBy_BusinessParticipant_RefID,
  mrs_mpt_notes.Text,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_bpt_businessparticipant_accesscodes.Code
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
  mrs_mpt_measuringpoints On mrs_rut_route_measuringpoints.MeasuringPoint_RefID
    = mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID Inner Join
  mrs_mpt_notes On mrs_mpt_notes.MeasuringPoint_RefID =
    mrs_mpt_measuringpoints.MRS_MPT_MeasuringPointID Inner Join
  cmn_bpt_businessparticipants
    On mrs_mpt_notes.CreatedBy_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_businessparticipant_accesscodes
    On
    cmn_bpt_businessparticipant_accesscodes.CMN_BPT_BusinessParticipant_AccessCodeID = mrs_run_measurementrun_accountdownloadcodes.Account_RefID
Where
  mrs_mpt_notes.IsDeleted = 0 And
  cmn_bpt_businessparticipant_accesscodes.Code = @AccountCode And
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_rut_routes.IsDeleted = 0 And
  mrs_rut_route_measuringpoints.IsDeleted = 0 And
  mrs_mpt_measuringpoints.IsDeleted = 0 And
  mrs_run_measurementrun_accountdownloadcodes.DownloadCode = @DownloadCode And
  mrs_run_measurementrun_accountdownloadcodes.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0