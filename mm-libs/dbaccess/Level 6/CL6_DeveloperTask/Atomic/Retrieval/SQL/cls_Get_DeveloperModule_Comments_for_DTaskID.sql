
   
Select
  tms_pro_comments.TMS_PRO_CommentID As CommentID,
  tms_pro_comments.Creation_Timestamp As CreationDate,
  tms_pro_comments.Comment_TextContent As CommentText,
  tms_pro_comments.IsDeleted As IsDeletedComment,
  tms_pro_comments.Comment_CreatedByAccount_RefID As CommentAccID,
  cmn_per_personinfo.FirstName As AuthorFirstName,
  cmn_per_personinfo.LastName As AuthorLastName,
  tms_pro_comments.Comment_BoundTo_DeveloperTask_RefID,
  tms_pro_comments.Comment_BoundTo_Project_RefID,
  ProfileImage.File_SourceLocation,
  ProfileImage.File_ServerLocation,
  tms_pro_comments.Comment_BoundTo_Feature_RefID
From
  tms_pro_comments Left Join
  usr_accounts On tms_pro_comments.Comment_CreatedByAccount_RefID =
    usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo_2_account On usr_accounts.USR_AccountID =
    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    doc_documents.DOC_DocumentID,
    doc_documentrevisions.File_SourceLocation,
    doc_documentrevisions.File_ServerLocation
  From
    doc_documents Inner Join
    doc_documentrevisions On doc_documents.DOC_DocumentID =
      doc_documentrevisions.Document_RefID
  Where
    doc_documents.IsDeleted = 0 And
    doc_documents.Tenant_RefID = @TenantID And
    doc_documentrevisions.IsDeleted = 0 And
    doc_documentrevisions.IsLastRevision = 1) ProfileImage
    On cmn_per_personinfo.ProfileImage_Document_RefID =
    ProfileImage.DOC_DocumentID
Where
  (tms_pro_comments.Comment_BoundTo_DeveloperTask_RefID = @DTaskID) Or
  (tms_pro_comments.Comment_BoundTo_Feature_RefID = @FeatureID) Or
  (tms_pro_comments.Comment_BoundTo_Project_RefID = @ProjectID)
Order By
  CreationDate Desc
 
  
