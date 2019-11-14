UPDATE 
	tms_pro_comment_mentions
SET 
	Comment_RefID=@Comment_RefID,
	IsMentionFor_Account=@IsMentionFor_Account,
	IsMentionFor_BusinessTask=@IsMentionFor_BusinessTask,
	IsMentionFor_Feature=@IsMentionFor_Feature,
	IsMentionFor_DeveloperTask=@IsMentionFor_DeveloperTask,
	Mention_Account_RefID=@Mention_Account_RefID,
	Mention_BusinessTask_RefID=@Mention_BusinessTask_RefID,
	Mention_Feature_RefID=@Mention_Feature_RefID,
	Mention_DeveloperTask_RefID=@Mention_DeveloperTask_RefID,
	CommentMention_Position=@CommentMention_Position,
	R_CommentMention_Text=@R_CommentMention_Text,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Comment_MentionID = @TMS_PRO_Comment_MentionID