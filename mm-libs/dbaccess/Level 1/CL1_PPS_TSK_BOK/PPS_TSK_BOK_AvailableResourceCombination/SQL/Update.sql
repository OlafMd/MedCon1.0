UPDATE 
	pps_tsk_bok_availableresourcecombinations
SET 
	BookableTimeSlot_RefID=@BookableTimeSlot_RefID,
	IsAvailable=@IsAvailable,
	IsUsedByOtherUsedConnectedResourceCombination=@IsUsedByOtherUsedConnectedResourceCombination,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	PPS_TSK_BOK_AvailableResourceCombinationID = @PPS_TSK_BOK_AvailableResourceCombinationID