UPDATE 
	tms_pro_comment_attachedfiles
SET 
	Comment_RefID=@Comment_RefID,
	AttachedFile_Document_RefID=@AttachedFile_Document_RefID,
	AttachedFile_DisplayName=@AttachedFile_DisplayName,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Comment_AttachedFileID = @TMS_PRO_Comment_AttachedFileID