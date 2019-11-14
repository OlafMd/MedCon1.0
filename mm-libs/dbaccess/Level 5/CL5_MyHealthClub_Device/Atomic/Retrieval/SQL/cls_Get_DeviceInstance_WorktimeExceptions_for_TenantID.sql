
Select
  pps_dev_devices.DeviceDisplayName,
  pps_dev_device_instances.DeviceInventoryNumber,
  cmn_cal_ava_dates.DateComment As Description,
  cmn_cal_events.IsRepetitive,
  cmn_cal_events.IsWholeDayEvent,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_repetitions.IsDaily,
  cmn_cal_repetitions.IsWeekly,
  cmn_cal_repetitions.IsMonthly,
  cmn_cal_repetitions.IsYearly,
  cmn_str_offices.Office_Name_DictID
From
  pps_dev_devices Inner Join
  pps_dev_device_instances On pps_dev_devices.PPS_DEV_DeviceID =
    pps_dev_device_instances.Device_RefID And
    pps_dev_device_instances.Tenant_RefID = @TenantID And
    pps_dev_device_instances.IsDeleted = 0 Inner Join
  pps_dev_device_instance_availabilities
    On pps_dev_device_instances.PPS_DEV_Device_InstanceID =
    pps_dev_device_instance_availabilities.DeviceInstance_RefID And
    pps_dev_device_instance_availabilities.Tenant_RefID = @TenantID And
    pps_dev_device_instance_availabilities.IsDeleted = 0 Inner Join
  cmn_cal_ava_availabilities
    On pps_dev_device_instance_availabilities.CMN_CAL_AVA_Availability_RefID =
    cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
    cmn_cal_ava_availabilities.IsDeleted = 0 And
    cmn_cal_ava_availabilities.Tenant_RefID = @TenantID Inner Join
  cmn_cal_ava_dates On cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID =
    cmn_cal_ava_dates.Availability_RefID And cmn_cal_ava_dates.Tenant_RefID =
    @TenantID And cmn_cal_ava_dates.IsDeleted = 0 Inner Join
  cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.Tenant_RefID = @TenantID
    And cmn_cal_events.IsDeleted = 0 Left Join
  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsDeleted =
    0 And cmn_cal_repetitions.Tenant_RefID = @TenantID Inner Join
  pps_dev_device_instance_officelocations On pps_dev_device_instances.PPS_DEV_Device_InstanceID =
    pps_dev_device_instance_officelocations.DeviceInstance_RefID And
    pps_dev_device_instance_officelocations.IsDeleted = 0 And
    pps_dev_device_instance_officelocations.Tenant_RefID = @TenantID Inner Join
  cmn_str_offices
    On pps_dev_device_instance_officelocations.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0
    And cmn_str_offices.Tenant_RefID = @TenantID
Where
  cmn_cal_ava_availabilities.IsAvailabilityExclusionItem = 1 And
  pps_dev_devices.Tenant_RefID = @TenantID And
  pps_dev_devices.IsDeleted = 0
  