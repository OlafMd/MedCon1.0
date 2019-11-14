
	Select
	  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
	  log_wrh_shelf_contents.Product_Variant_RefID,
	  Coalesce(log_wrh_shelf_contents.Quantity_Current, 0) As CurrentQuantity,
	  Sum(Coalesce(log_rsv_reservations.ReservedQuantity, 0)) As ReservedQuantity,
	  (Coalesce(log_wrh_shelf_contents.Quantity_Current, 0) -
	  Sum(Coalesce(log_rsv_reservations.ReservedQuantity, 0))) As FreeQuantity
	From
	  log_wrh_shelf_contents Left Join
	  log_rsv_reservations On log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID =
	    log_rsv_reservations.LOG_WRH_Shelf_Content_RefID And
	    log_rsv_reservations.IsDeleted = 0 And
	    log_rsv_reservations.IsReservationExecuted = 0 And
	    log_rsv_reservations.Tenant_RefID = @TenantID
	Where
	  log_wrh_shelf_contents.Product_Variant_RefID = @ProductVatiantIDList And
	  log_wrh_shelf_contents.IsDeleted = 0 And
	  log_wrh_shelf_contents.Tenant_RefID = @TenantID And
	  log_wrh_shelf_contents.Quantity_Current > 0
	Group By
	  log_wrh_shelf_contents.Product_Variant_RefID,
	  Coalesce(log_wrh_shelf_contents.Quantity_Current, 0)
  