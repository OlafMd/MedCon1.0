INSERT INTO 
	tms_pro_request_comments
	(
		TMS_PRO_Request_CommentID,
		CreatedBy_Account_RefID,
		AnswerRequestedFor_Account_RefID,
		Request_RefID,
		Description,
		IsClosingComment,
		IsReopeningComment,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@TMS_PRO_Request_CommentID,
		@CreatedBy_Account_RefID,
		@AnswerRequestedFor_Account_RefID,
		@Request_RefID,
		@Description,
		@IsClosingComment,
		@IsReopeningComment,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)