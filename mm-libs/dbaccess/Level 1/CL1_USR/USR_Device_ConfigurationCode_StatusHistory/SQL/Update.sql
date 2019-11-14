UPDATE 
	usr_device_configurationcode_statushistory
SET 
	Device_ConfigurationCode_RefID=@Device_ConfigurationCode_RefID,
	WasUsed=@WasUsed,
	WasUsedBy_UserDevice_RefID=@WasUsedBy_UserDevice_RefID,
	WasDeactivated=@WasDeactivated,
	WasDeactivatedBy_BusinessParticipant_RefID=@WasDeactivatedBy_BusinessParticipant_RefID,
	WasDeleted=@WasDeleted,
	WasDeletedBy_BusinessParticipant_RefID=@WasDeletedBy_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	USR_Device_ConfigurationCode_StatusHistoryID = @USR_Device_ConfigurationCode_StatusHistoryID