UPDATE 
	tms_pro_requests
SET 
	CreatedBy_Account_RefID=@CreatedBy_Account_RefID,
	RequestNumber=@RequestNumber,
	RequestTitle=@RequestTitle,
	R_CurrentAssignee_Account_RefID=@R_CurrentAssignee_Account_RefID,
	R_IsOpen=@R_IsOpen,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Progress=@Progress
WHERE 
	TMS_PRO_RequestID = @TMS_PRO_RequestID