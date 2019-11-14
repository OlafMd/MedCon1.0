UPDATE 
	hec_app_appointments
SET 
	Ext_PPS_TSK_Task_RefID=@Ext_PPS_TSK_Task_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_APP_AppointmentID = @HEC_APP_AppointmentID