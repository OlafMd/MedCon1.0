UPDATE 
	hec_patient_event_types
SET 
	EventType_Name_DictID=@EventType_Name,
	EventType_Description_DictID=@EventType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Event_TypeID = @HEC_Patient_Event_TypeID