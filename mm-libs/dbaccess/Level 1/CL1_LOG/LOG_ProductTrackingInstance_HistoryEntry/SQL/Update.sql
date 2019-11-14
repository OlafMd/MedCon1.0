UPDATE 
	log_producttrackinginstance_historyentries
SET 
	ProductTrackingInstance_RefID=@ProductTrackingInstance_RefID,
	HistoryEntry_Text=@HistoryEntry_Text,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_ProductTrackingInstance_HistoryEntryID = @LOG_ProductTrackingInstance_HistoryEntryID