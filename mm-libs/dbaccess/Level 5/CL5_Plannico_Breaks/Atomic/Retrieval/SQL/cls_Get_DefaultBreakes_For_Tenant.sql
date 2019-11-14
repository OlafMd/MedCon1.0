
	Select
  cmn_pps_breaktime_defaults.CMN_PPS_BreakTime_DefaultID,
  cmn_pps_breaktime_defaults.BreakTime_Template_RefID,
  cmn_pps_breaktime_defaults.ExpectedWorkTime_in_sec,
  cmn_pps_breaktime_defaults.ValidFromTimeOffset_in_sec,
  cmn_pps_breaktime_defaults.ValidToTimeOffset_in_sec,
  cmn_pps_breaktime_defaults_structurebindings.BoundTo_Office_RefID,
  cmn_pps_breaktime_defaults_structurebindings.BoundTo_WorkArea_RefID,
  cmn_pps_breaktime_defaults_structurebindings.BoundTo_Workplace_RefID
From
  cmn_pps_breaktime_defaults Inner Join
  cmn_pps_breaktime_defaults_structurebindings
    On cmn_pps_breaktime_defaults.CMN_PPS_BreakTime_DefaultID =
    cmn_pps_breaktime_defaults_structurebindings.BreakTime_Default_RefID
Where
  cmn_pps_breaktime_defaults.Tenant_RefID = @TenantID And
  cmn_pps_breaktime_defaults.IsDeleted = 0
  