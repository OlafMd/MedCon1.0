INSERT INTO 
	cmn_cal_ava_availability_types
	(
		CMN_CAL_AVA_Availability_TypeID,
		GlobalPropertyMatchingID,
		AvailabilityTypeName_DictID,
		IsDefaultAvailabilityType,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_CAL_AVA_Availability_TypeID,
		@GlobalPropertyMatchingID,
		@AvailabilityTypeName,
		@IsDefaultAvailabilityType,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)