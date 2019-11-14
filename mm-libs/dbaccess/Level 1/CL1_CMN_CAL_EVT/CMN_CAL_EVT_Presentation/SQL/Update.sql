UPDATE 
	cmn_cal_evt_presentations
SET 
	Ext_CMN_CAL_Calendar_RefID=@Ext_CMN_CAL_Calendar_RefID,
	PresentationLocation=@PresentationLocation,
	MaximumNumberOfParticipants=@MaximumNumberOfParticipants,
	PresentationTitle_DictID=@PresentationTitle,
	PresentationDescription_DictID=@PresentationDescription,
	IsFeaturedEvent=@IsFeaturedEvent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_EVT_PresentationID = @CMN_CAL_EVT_PresentationID