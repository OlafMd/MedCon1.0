UPDATE 
	cmn_cal_ava_availability_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	AvailabilityTypeName_DictID=@AvailabilityTypeName,
	IsDefaultAvailabilityType=@IsDefaultAvailabilityType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_AVA_Availability_TypeID = @CMN_CAL_AVA_Availability_TypeID