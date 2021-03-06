INSERT INTO 
	hec_patient_events
	(
		HEC_Patient_EventID,
		Patient_RefID,
		Event_Date,
		Event_Type_RefID,
		R_Event_Description,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_Patient_EventID,
		@Patient_RefID,
		@Event_Date,
		@Event_Type_RefID,
		@R_Event_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)