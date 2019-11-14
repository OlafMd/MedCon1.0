
	Select
	  pps_dev_devices.PPS_DEV_DeviceID,
	  pps_dev_devices.DeviceDisplayName
	From
	  pps_dev_devices
	Where
	  pps_dev_devices.IsDeleted = 0 And
	  pps_dev_devices.Tenant_RefID = @TenantID
  