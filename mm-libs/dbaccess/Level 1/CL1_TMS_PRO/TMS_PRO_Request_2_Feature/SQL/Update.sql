UPDATE 
	tms_pro_request_2_feature
SET 
	TMS_PRO_Request_RefID=@TMS_PRO_Request_RefID,
	TMS_PRO_Feature_RefID=@TMS_PRO_Feature_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID