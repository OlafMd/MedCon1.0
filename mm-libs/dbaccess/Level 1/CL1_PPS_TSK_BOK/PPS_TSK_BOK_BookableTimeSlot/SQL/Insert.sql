INSERT INTO 
	pps_tsk_bok_bookabletimeslots
	(
		PPS_TSK_BOK_BookableTimeSlotID,
		FreeSlotsForTaskTemplateITPL,
		TaskTemplate_RefID,
		Office_RefID,
		FreeInterval_Start,
		FreeInterval_End,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@PPS_TSK_BOK_BookableTimeSlotID,
		@FreeSlotsForTaskTemplateITPL,
		@TaskTemplate_RefID,
		@Office_RefID,
		@FreeInterval_Start,
		@FreeInterval_End,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)