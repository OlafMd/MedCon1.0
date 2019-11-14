UPDATE 
	bil_notes
SET 
	BillHeader_RefID=@BillHeader_RefID,
	BillPosition_RefID=@BillPosition_RefID,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Title=@Title,
	NoteText=@NoteText,
	SequenceOrderNumber=@SequenceOrderNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_Note = @BIL_Note