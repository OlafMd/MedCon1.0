UPDATE 
	cmn_cal_evt_presenters
SET 
	Presentation_RefID=@Presentation_RefID,
	CMN_PersonInfo_RefID=@CMN_PersonInfo_RefID,
	PresenterDisplayName=@PresenterDisplayName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_EVT_PresenterID = @CMN_CAL_EVT_PresenterID