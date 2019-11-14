UPDATE 
	hec_patient_events
SET 
	Patient_RefID=@Patient_RefID,
	Event_Date=@Event_Date,
	Event_Type_RefID=@Event_Type_RefID,
	R_Event_Description=@R_Event_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_EventID = @HEC_Patient_EventID