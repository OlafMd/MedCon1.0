UPDATE 
	cmn_notes
SET 
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Current_NoteRevision_RefID=@Current_NoteRevision_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_NoteID = @CMN_NoteID