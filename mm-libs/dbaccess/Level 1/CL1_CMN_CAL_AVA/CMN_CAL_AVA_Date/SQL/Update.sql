UPDATE 
	cmn_cal_ava_dates
SET 
	Availability_RefID=@Availability_RefID,
	CMN_CAL_Event_RefID=@CMN_CAL_Event_RefID,
	DateName=@DateName,
	DateComment=@DateComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_AVA_DateID = @CMN_CAL_AVA_DateID