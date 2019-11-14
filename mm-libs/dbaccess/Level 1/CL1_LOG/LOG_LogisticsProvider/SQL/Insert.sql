INSERT INTO 
	log_logisticsproviders
	(
		LOG_LogisticsProviderID,
		Ext_CMN_BPT_BusinessParticipant_RefID,
		IsProviding_TransportServices,
		IsTrackingAvailable,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@LOG_LogisticsProviderID,
		@Ext_CMN_BPT_BusinessParticipant_RefID,
		@IsProviding_TransportServices,
		@IsTrackingAvailable,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)