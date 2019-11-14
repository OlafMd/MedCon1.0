UPDATE 
	usr_mobiledevice_pushdata
SET 
	cloud_connection_id=@cloud_connection_id,
	DeviceType=@DeviceType,
	Application_RefID=@Application_RefID,
	Account_RefID=@Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	USR_mobiledevice_pushdata_ID = @USR_mobiledevice_pushdata_ID