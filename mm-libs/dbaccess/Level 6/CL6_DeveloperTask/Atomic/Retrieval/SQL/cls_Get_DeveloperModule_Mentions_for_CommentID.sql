
   
Select
  tms_pro_comment_mentions.TMS_PRO_Comment_MentionID,
  tms_pro_comment_mentions.Comment_RefID,
  tms_pro_comment_mentions.R_CommentMention_Text,
  tms_pro_comment_mentions.CommentMention_Position,
  tms_pro_comment_mentions.Creation_Timestamp,
  tms_pro_comment_mentions.IsDeleted
From
  tms_pro_comment_mentions
Where
  tms_pro_comment_mentions.Comment_RefID = @CommentID And
  tms_pro_comment_mentions.IsDeleted = 0
   
 
  
