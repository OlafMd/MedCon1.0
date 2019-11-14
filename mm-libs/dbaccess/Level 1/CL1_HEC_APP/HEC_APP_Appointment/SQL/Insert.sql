INSERT INTO 
	hec_app_appointments
	(
		HEC_APP_AppointmentID,
		Ext_PPS_TSK_Task_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_APP_AppointmentID,
		@Ext_PPS_TSK_Task_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)