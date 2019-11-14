UPDATE 
	cmn_tenant_activeapprovalprocesstypes
SET 
	Tenant_RefID=@Tenant_RefID,
	CMN_CAL_Event_ApprovalProcess_Type_RefID=@CMN_CAL_Event_ApprovalProcess_Type_RefID,
	IsActive=@IsActive,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	CMN_Tenant_ActiveApprovalProcessTypeID = @CMN_Tenant_ActiveApprovalProcessTypeID