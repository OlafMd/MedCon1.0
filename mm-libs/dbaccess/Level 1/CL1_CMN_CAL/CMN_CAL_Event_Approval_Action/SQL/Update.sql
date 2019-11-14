UPDATE 
	cmn_cal_event_approval_actions
SET 
	EventApproval_RefID=@EventApproval_RefID,
	ActionTriggeredBy_Account_RefID=@ActionTriggeredBy_Account_RefID,
	IsApproval=@IsApproval,
	IsRevocation=@IsRevocation,
	IsDenial=@IsDenial,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Event_Approval_ActionID = @CMN_CAL_Event_Approval_ActionID