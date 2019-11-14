UPDATE 
	log_rsv_reservation_shelfcontent_history
SET 
	LOG_WRH_Shelf_Content_RefID=@LOG_WRH_Shelf_Content_RefID,
	IsReservationMade=@IsReservationMade,
	IsReservationReleased=@IsReservationReleased,
	NewReservedQuantity=@NewReservedQuantity,
	ReservedQuantity=@ReservedQuantity,
	ReleasedQuantity=@ReleasedQuantity,
	Comment=@Comment,
	IfReservationMade_Reservation_RefID=@IfReservationMade_Reservation_RefID,
	IfReservationReleased_ReleasedReservation_RefID=@IfReservationReleased_ReleasedReservation_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RSV_Reservation_ShelfContent_HistoryID = @LOG_RSV_Reservation_ShelfContent_HistoryID