
Select Distinct
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  usr_devices.DeviceName,
  usr_devices.DeviceVendor,
  usr_device_configurationcodes.DeviceConfigurationCode,
  usr_devices.USR_DeviceID,
  usr_accounts.USR_AccountID,
  usr_devices.IsBanned
From
  usr_accounts Inner Join
  hec_doctors On usr_accounts.USR_AccountID = hec_doctors.Account_RefID And
    hec_doctors.IsDeleted = 0 And hec_doctors.Tenant_RefID = @TenantID
  Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  usr_device_configurationcodes On usr_accounts.USR_AccountID =
    usr_device_configurationcodes.Preconfigured_PrimaryUser_RefID And
    usr_device_configurationcodes.IsDeleted = 0 And
    usr_device_configurationcodes.Tenant_RefID = @TenantID Left Join
  usr_device_activityhistory
    On usr_device_configurationcodes.USR_Device_ConfigurationCodeID =
    usr_device_activityhistory.WasDevice_Configured_WithConfigurationCode_RefID
    And usr_device_activityhistory.Tenant_RefID = @TenantID And
    usr_device_activityhistory.IsDeleted = 0 Left Join
  usr_devices On usr_device_activityhistory.Device_RefID =
    usr_devices.USR_DeviceID And usr_devices.IsDeleted = 0 And
    usr_devices.Tenant_RefID = @TenantID
Where
  usr_accounts.IsDeleted = 0 And
  usr_accounts.Tenant_RefID = @TenantID
  