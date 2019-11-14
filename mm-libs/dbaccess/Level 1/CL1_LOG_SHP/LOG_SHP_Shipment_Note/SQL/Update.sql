UPDATE 
	log_shp_shipment_notes
SET 
	Shipment_Header_RefID=@Shipment_Header_RefID,
	Shipment_Position_RefID=@Shipment_Position_RefID,
	IsNotePrintedOnDeliveryPaper=@IsNotePrintedOnDeliveryPaper,
	Title=@Title,
	Comment=@Comment,
	NotePublishDate=@NotePublishDate,
	SequenceOrderNumber=@SequenceOrderNumber,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_Shipment_NoteID = @LOG_SHP_Shipment_NoteID