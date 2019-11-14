UPDATE 
	mrs_run_measurement_notes
SET 
	MRS_RUN_Measurement_RefID=@MRS_RUN_Measurement_RefID,
	NoteText=@NoteText,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	MRS_RUN_Measurement_NoteID = @MRS_RUN_Measurement_NoteID