UPDATE 
	tms_pro_request_comments
SET 
	CreatedBy_Account_RefID=@CreatedBy_Account_RefID,
	AnswerRequestedFor_Account_RefID=@AnswerRequestedFor_Account_RefID,
	Request_RefID=@Request_RefID,
	Description=@Description,
	IsClosingComment=@IsClosingComment,
	IsReopeningComment=@IsReopeningComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_Request_CommentID = @TMS_PRO_Request_CommentID