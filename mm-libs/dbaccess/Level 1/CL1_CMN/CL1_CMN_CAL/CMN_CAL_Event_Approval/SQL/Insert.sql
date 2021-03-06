INSERT INTO 
	cmn_cal_event_approvals
	(
		CMN_CAL_Event_ApprovalID,
		ApprovalProcess_Type_RefID,
		Event_RefID,
		IsApproved,
		IsApprovalProcessOpened,
		IsApprovalProcessDenied,
		IsApprovalProcessCanceledByUser,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CAL_Event_ApprovalID,
		@ApprovalProcess_Type_RefID,
		@Event_RefID,
		@IsApproved,
		@IsApprovalProcessOpened,
		@IsApprovalProcessDenied,
		@IsApprovalProcessCanceledByUser,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)