
Select Distinct
  pps_dev_device_instances.PPS_DEV_Device_InstanceID,
  pps_dev_devices.PPS_DEV_DeviceID,
  pps_dev_devices.DeviceDisplayName,
  pps_dev_device_instances.DeviceInventoryNumber,
  pps_dev_device_instance_officelocations.PPS_DEV_Device_Instance_OfficeLocationID,
  pps_dev_device_instance_officelocations.CMN_STR_Office_RefID
From
  pps_dev_devices Inner Join
  pps_dev_device_instances On pps_dev_device_instances.Device_RefID =
    pps_dev_devices.PPS_DEV_DeviceID Left Join
  pps_dev_device_instance_officelocations
    On pps_dev_device_instance_officelocations.DeviceInstance_RefID =
    pps_dev_device_instances.PPS_DEV_Device_InstanceID And
    (pps_dev_device_instance_officelocations.IsDeleted = 0 Or
      pps_dev_device_instance_officelocations.IsDeleted Is Null)
Where
  pps_dev_device_instances.PPS_DEV_Device_InstanceID = @DeviceInstanceID And
  pps_dev_devices.IsDeleted = 0 And
  pps_dev_device_instances.IsDeleted = 0 And
  pps_dev_devices.Tenant_RefID = @TenantID
  