UPDATE 
	cmn_cal_ava_availabilities
SET 
	AvailabilityType_RefID=@AvailabilityType_RefID,
	AvailabilityComment=@AvailabilityComment,
	IsAvailabilityExclusionItem=@IsAvailabilityExclusionItem,
	Office_RefID=@Office_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_AVA_AvailabilityID = @CMN_CAL_AVA_AvailabilityID