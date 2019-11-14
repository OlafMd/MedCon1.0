INSERT INTO 
	log_shp_returnshipment_receivablecreditnote_headers
	(
		LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID,
		Ext_ACC_CRN_ReceivedCreditNote_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID,
		@Ext_ACC_CRN_ReceivedCreditNote_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)