INSERT INTO 
	cmn_bpt_sta_absencereason_emailsubscriptions
	(
		CMN_BPT_STA_AbsenceReason_EmailSubscriptionID,
		CMN_STR_Office_RefID,
		AbsenceReason_RefID,
		EmailAddresses,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_STA_AbsenceReason_EmailSubscriptionID,
		@CMN_STR_Office_RefID,
		@AbsenceReason_RefID,
		@EmailAddresses,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)