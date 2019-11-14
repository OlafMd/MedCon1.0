
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  mrs_run_measurementrun_routes.Route_RefID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  mrs_run_measurementrun_routes
    On mrs_run_measurementrun_routes.BoundTo_Account_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  mrs_run_measurementrun_routes.IsDeleted = 0 And
  mrs_run_measurementrun_routes.MeasurementRun_RefID = @MeasurementRunID
  