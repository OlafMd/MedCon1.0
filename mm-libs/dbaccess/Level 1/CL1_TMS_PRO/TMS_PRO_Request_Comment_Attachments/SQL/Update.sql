UPDATE 
	tms_pro_request_comment_attachments
SET 
	Document_RefID=@Document_RefID,
	TMS_PRO_Request_Comment_RefID=@TMS_PRO_Request_Comment_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_Request_Comment_AttachmentID = @TMS_PRO_Request_Comment_AttachmentID