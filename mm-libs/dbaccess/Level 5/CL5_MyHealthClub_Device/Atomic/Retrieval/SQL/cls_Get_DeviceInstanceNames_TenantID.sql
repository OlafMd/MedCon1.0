
Select
  pps_dev_devices.DeviceDisplayName,
  pps_dev_device_instances.DeviceInventoryNumber,
  pps_dev_device_instances.PPS_DEV_Device_InstanceID
From
  pps_dev_devices Inner Join
  pps_dev_device_instances On pps_dev_devices.PPS_DEV_DeviceID =
    pps_dev_device_instances.Device_RefID And
    pps_dev_device_instances.Tenant_RefID = @TenantID And
    pps_dev_device_instances.IsDeleted = 0 Inner Join
  pps_dev_device_instance_officelocations
    On pps_dev_device_instances.PPS_DEV_Device_InstanceID =
    pps_dev_device_instance_officelocations.DeviceInstance_RefID And
    pps_dev_device_instance_officelocations.IsDeleted = 0 And
    pps_dev_device_instance_officelocations.Tenant_RefID = @TenantID
Where
  pps_dev_devices.Tenant_RefID = @TenantID And
  pps_dev_devices.IsDeleted = 0
  