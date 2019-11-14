UPDATE 
	pps_tsk_bok_bookabletimeslots
SET 
	FreeSlotsForTaskTemplateITPL=@FreeSlotsForTaskTemplateITPL,
	TaskTemplate_RefID=@TaskTemplate_RefID,
	Office_RefID=@Office_RefID,
	FreeInterval_Start=@FreeInterval_Start,
	FreeInterval_End=@FreeInterval_End,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	PPS_TSK_BOK_BookableTimeSlotID = @PPS_TSK_BOK_BookableTimeSlotID