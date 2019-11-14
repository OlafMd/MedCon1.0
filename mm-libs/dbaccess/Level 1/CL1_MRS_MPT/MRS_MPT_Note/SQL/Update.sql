UPDATE 
	mrs_mpt_notes
SET 
	Text=@Text,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	SequenceNumber=@SequenceNumber,
	MeasuringPoint_RefID=@MeasuringPoint_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	MRS_MPT_NoteID = @MRS_MPT_NoteID