
Select Distinct
  pps_dev_device_instances.PPS_DEV_Device_InstanceID,
  pps_dev_devices.PPS_DEV_DeviceID,
  pps_dev_devices.DeviceDisplayName,
  pps_dev_device_instances.DeviceInventoryNumber,
  pps_dev_device_instance_officelocations.PPS_DEV_Device_Instance_OfficeLocationID,
  cmn_str_offices.Office_Name_DictID
From
  pps_dev_devices Inner Join
  pps_dev_device_instances On pps_dev_device_instances.Device_RefID =
    pps_dev_devices.PPS_DEV_DeviceID Left Join
  pps_dev_device_instance_officelocations
    On pps_dev_device_instance_officelocations.DeviceInstance_RefID =
    pps_dev_device_instances.PPS_DEV_Device_InstanceID And
    (pps_dev_device_instance_officelocations.IsDeleted = 0 Or
      pps_dev_device_instance_officelocations.IsDeleted Is Null) Left Join
  cmn_str_offices
    On pps_dev_device_instance_officelocations.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And (cmn_str_offices.IsDeleted = 0 Or
      cmn_str_offices.IsDeleted Is Null)
Where
  pps_dev_devices.IsDeleted = 0 And
  pps_dev_device_instances.IsDeleted = 0 And
  pps_dev_devices.Tenant_RefID = @TenantID
  