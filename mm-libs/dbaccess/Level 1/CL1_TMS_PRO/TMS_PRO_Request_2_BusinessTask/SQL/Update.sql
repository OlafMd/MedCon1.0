UPDATE 
	tms_pro_request_2_businesstask
SET 
	TMS_PRO_Request_RefID=@TMS_PRO_Request_RefID,
	TMS_PRO_BusinessTask_RefID=@TMS_PRO_BusinessTask_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID