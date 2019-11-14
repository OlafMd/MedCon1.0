
Select
  log_wrh_shelf_contents.Product_RefID,
  Sum(log_wrh_shelf_contents.Quantity_Current) As CurrentQuantity,
  Reservations.ReservedQuantity
From
  log_wrh_shelf_contents Inner Join
  (Select
    Sum(log_rsv_reservations.ReservedQuantity) As ReservedQuantity,
    log_wrh_shelf_contents.Product_RefID
  From
    log_rsv_reservations Inner Join
    log_wrh_shelf_contents On log_rsv_reservations.LOG_WRH_Shelf_Content_RefID =
      log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
  Where
    log_wrh_shelf_contents.IsDeleted = 0 And
    log_rsv_reservations.IsDeleted = 0 And
    log_rsv_reservations.IsReservationExecuted = 0 And
    log_wrh_shelf_contents.Product_RefID = @ProductIDList
  Group By
    log_wrh_shelf_contents.Product_RefID) Reservations
    On log_wrh_shelf_contents.Product_RefID = Reservations.Product_RefID
Where
  log_wrh_shelf_contents.IsDeleted = 0 And
  log_wrh_shelf_contents.Product_RefID = @ProductIDList
Group By
  log_wrh_shelf_contents.Product_RefID, Reservations.ReservedQuantity
  