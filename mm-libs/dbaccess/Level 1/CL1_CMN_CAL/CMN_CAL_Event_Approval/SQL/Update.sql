UPDATE 
	cmn_cal_event_approvals
SET 
	ApprovalProcess_Type_RefID=@ApprovalProcess_Type_RefID,
	Event_RefID=@Event_RefID,
	IsApproved=@IsApproved,
	IsApprovalProcessOpened=@IsApprovalProcessOpened,
	IsApprovalProcessDenied=@IsApprovalProcessDenied,
	IsApprovalProcessCanceledByUser=@IsApprovalProcessCanceledByUser,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Event_ApprovalID = @CMN_CAL_Event_ApprovalID