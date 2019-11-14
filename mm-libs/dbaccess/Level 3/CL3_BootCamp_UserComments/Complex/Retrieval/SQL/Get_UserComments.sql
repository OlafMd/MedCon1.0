
  Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  tms_pro_comments.Comment_TextContent,
  Count(tms_pro_comment_attachedfiles.AttachedFile_Document_RefID) AS NumberOfDocs
From
  tms_pro_comments Inner Join
  tms_pro_comment_mentions On tms_pro_comment_mentions.Comment_RefID =
    tms_pro_comments.TMS_PRO_CommentID Inner Join
  cmn_per_personinfo_2_account
    On tms_pro_comments.Comment_CreatedByAccount_RefID =
    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  tms_pro_comment_attachedfiles On tms_pro_comment_attachedfiles.Comment_RefID =
    tms_pro_comments.TMS_PRO_CommentID

        
 