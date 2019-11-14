UPDATE 
	log_logisticsproviders
SET 
	Ext_CMN_BPT_BusinessParticipant_RefID=@Ext_CMN_BPT_BusinessParticipant_RefID,
	IsProviding_TransportServices=@IsProviding_TransportServices,
	IsTrackingAvailable=@IsTrackingAvailable,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	LOG_LogisticsProviderID = @LOG_LogisticsProviderID