UPDATE 
	pps_tsk_bok_bookabletimeslots_2_availabilitytypes
SET 
	PPS_TSK_BOK_BookableTimeSlot_RefID=@PPS_TSK_BOK_BookableTimeSlot_RefID,
	CMN_CAL_AVA_Availability_TypeID=@CMN_CAL_AVA_Availability_TypeID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID