INSERT INTO 
	cmn_bpt_businessparticipant_2_businessparticipantgroup
	(
		AssignmentID,
		CMN_BPT_BusinessParticipant_RefID,
		CMN_BPT_BusinessParticipant_Group_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@CMN_BPT_BusinessParticipant_RefID,
		@CMN_BPT_BusinessParticipant_Group_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)