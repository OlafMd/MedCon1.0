INSERT INTO 
	mrs_mpt_notes
	(
		MRS_MPT_NoteID,
		Text,
		CreatedBy_BusinessParticipant_RefID,
		SequenceNumber,
		MeasuringPoint_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@MRS_MPT_NoteID,
		@Text,
		@CreatedBy_BusinessParticipant_RefID,
		@SequenceNumber,
		@MeasuringPoint_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)