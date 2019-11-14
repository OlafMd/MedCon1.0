INSERT INTO 
	log_producttrackinginstance_historyentries
	(
		LOG_ProductTrackingInstance_HistoryEntryID,
		ProductTrackingInstance_RefID,
		HistoryEntry_Text,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_ProductTrackingInstance_HistoryEntryID,
		@ProductTrackingInstance_RefID,
		@HistoryEntry_Text,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)