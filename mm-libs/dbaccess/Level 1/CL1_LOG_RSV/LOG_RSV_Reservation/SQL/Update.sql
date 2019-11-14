UPDATE 
	log_rsv_reservations
SET 
	LOG_WRH_Shelf_Content_RefID=@LOG_WRH_Shelf_Content_RefID,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	ReservedQuantity=@ReservedQuantity,
	IsReservationExpirable=@IsReservationExpirable,
	ReservationExpiryDate=@ReservationExpiryDate,
	IsReservationExecuted=@IsReservationExecuted,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RSV_ReservationID = @LOG_RSV_ReservationID