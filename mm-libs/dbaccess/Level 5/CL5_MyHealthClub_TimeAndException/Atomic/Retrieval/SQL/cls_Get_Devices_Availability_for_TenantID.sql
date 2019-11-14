
Select
  cmn_cal_ava_availability_types.IsDefaultAvailabilityType,
  cmn_cal_ava_availability_types.GlobalPropertyMatchingID,
  cmn_cal_ava_dates.DateName,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_repetitions.IsMonthly,
  cmn_cal_repetitions.IsYearly,
  cmn_cal_repetitions.IsWeekly,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Mondays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Tuesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Wednesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Thursdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Fridays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Saturdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Sundays,
  cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID,
  cmn_cal_ava_availabilities.IsAvailabilityExclusionItem,
  cmn_cal_events.IsWholeDayEvent,
  cmn_cal_events.IsRepetitive,
  cmn_cal_repetitions.IsDaily,
  cmn_cal_ava_availability_types.Creation_Timestamp,
  cmn_cal_ava_dates.DateComment As Reason,
  pps_dev_device_instance_officelocations.CMN_STR_Office_RefID,
  pps_dev_device_instances.PPS_DEV_Device_InstanceID,
  pps_dev_device_instances.Device_RefID
From
  cmn_cal_ava_availabilities Left Join
  cmn_cal_ava_availability_types
    On cmn_cal_ava_availabilities.AvailabilityType_RefID =
    cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID And
    cmn_cal_ava_availability_types.Tenant_RefID = @TenantID And
    cmn_cal_ava_availability_types.IsDeleted = 0 Left Join
  cmn_cal_ava_dates On cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID =
    cmn_cal_ava_dates.Availability_RefID And cmn_cal_ava_dates.Tenant_RefID =
    @TenantID And cmn_cal_ava_dates.IsDeleted = 0 Left Join
  cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.IsDeleted = 0 And
    cmn_cal_events.Tenant_RefID = @TenantID Left Join
  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
    0 And cmn_cal_repetitions.Tenant_RefID = @TenantID Left Join
  cmn_cal_repetitionpatterns_weekly On cmn_cal_repetitions.CMN_CAL_RepetitionID
    = cmn_cal_repetitionpatterns_weekly.Repetition_RefID And
    cmn_cal_repetitionpatterns_weekly.IsDeleted = 0 And
    cmn_cal_repetitionpatterns_weekly.Tenant_RefID = @TenantID Right Join
  pps_dev_device_instance_availabilities
    On pps_dev_device_instance_availabilities.CMN_CAL_AVA_Availability_RefID =
    cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID Inner Join
  pps_dev_device_instances
    On pps_dev_device_instance_availabilities.DeviceInstance_RefID =
    pps_dev_device_instances.PPS_DEV_Device_InstanceID Inner Join
  pps_dev_device_instance_officelocations
    On pps_dev_device_instances.PPS_DEV_Device_InstanceID =
    pps_dev_device_instance_officelocations.DeviceInstance_RefID
Where
  pps_dev_device_instance_availabilities.IsDeleted = 0 And
  pps_dev_device_instance_availabilities.Tenant_RefID = @TenantID And
  pps_dev_device_instance_officelocations.IsDeleted = 0 And
  pps_dev_device_instances.IsDeleted = 0
  