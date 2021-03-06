INSERT INTO 
	log_shp_shipment_notes
	(
		LOG_SHP_Shipment_NoteID,
		Shipment_Header_RefID,
		Shipment_Position_RefID,
		IsNotePrintedOnDeliveryPaper,
		Title,
		Comment,
		NotePublishDate,
		SequenceOrderNumber,
		CreatedBy_BusinessParticipant_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_SHP_Shipment_NoteID,
		@Shipment_Header_RefID,
		@Shipment_Position_RefID,
		@IsNotePrintedOnDeliveryPaper,
		@Title,
		@Comment,
		@NotePublishDate,
		@SequenceOrderNumber,
		@CreatedBy_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)