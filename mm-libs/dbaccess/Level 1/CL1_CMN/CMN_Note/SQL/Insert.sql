INSERT INTO 
	cmn_notes
	(
		CMN_NoteID,
		CreatedBy_BusinessParticipant_RefID,
		Current_NoteRevision_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_NoteID,
		@CreatedBy_BusinessParticipant_RefID,
		@Current_NoteRevision_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)