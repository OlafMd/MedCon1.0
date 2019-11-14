UPDATE 
	cmn_noterevisions
SET 
	Note_RefID=@Note_RefID,
	Title=@Title,
	Content=@Content,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Version=@Version,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_NoteRevisionID = @CMN_NoteRevisionID