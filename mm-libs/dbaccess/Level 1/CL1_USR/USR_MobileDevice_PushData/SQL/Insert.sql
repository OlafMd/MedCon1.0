INSERT INTO 
	usr_mobiledevice_pushdata
	(
		USR_mobiledevice_pushdata_ID,
		cloud_connection_id,
		DeviceType,
		Application_RefID,
		Account_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@USR_mobiledevice_pushdata_ID,
		@cloud_connection_id,
		@DeviceType,
		@Application_RefID,
		@Account_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)