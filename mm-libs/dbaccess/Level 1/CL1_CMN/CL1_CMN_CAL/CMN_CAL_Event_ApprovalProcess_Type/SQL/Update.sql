UPDATE 
	cmn_cal_event_approvalprocess_types
SET 
	IsResponsiblePersonBased=@IsResponsiblePersonBased,
	IfResponsiblePersonBased_RefID=@IfResponsiblePersonBased_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CAL_Event_ApprovalProcess_TypeID = @CMN_CAL_Event_ApprovalProcess_TypeID