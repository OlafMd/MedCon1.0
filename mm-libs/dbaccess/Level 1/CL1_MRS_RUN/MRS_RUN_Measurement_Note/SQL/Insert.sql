INSERT INTO 
	mrs_run_measurement_notes
	(
		MRS_RUN_Measurement_NoteID,
		MRS_RUN_Measurement_RefID,
		NoteText,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@MRS_RUN_Measurement_NoteID,
		@MRS_RUN_Measurement_RefID,
		@NoteText,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)