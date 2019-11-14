INSERT INTO 
	tms_pro_comment_mentions
	(
		TMS_PRO_Comment_MentionID,
		Comment_RefID,
		IsMentionFor_Account,
		IsMentionFor_BusinessTask,
		IsMentionFor_Feature,
		IsMentionFor_DeveloperTask,
		Mention_Account_RefID,
		Mention_BusinessTask_RefID,
		Mention_Feature_RefID,
		Mention_DeveloperTask_RefID,
		CommentMention_Position,
		R_CommentMention_Text,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_Comment_MentionID,
		@Comment_RefID,
		@IsMentionFor_Account,
		@IsMentionFor_BusinessTask,
		@IsMentionFor_Feature,
		@IsMentionFor_DeveloperTask,
		@Mention_Account_RefID,
		@Mention_BusinessTask_RefID,
		@Mention_Feature_RefID,
		@Mention_DeveloperTask_RefID,
		@CommentMention_Position,
		@R_CommentMention_Text,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)