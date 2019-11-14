
	Select
	  Sum(log_wrh_shelf_contents.Quantity_Current) As CurrentQuantity,
	  Sum(log_wrh_shelf_contents.Quantity_Initial) As InitialQuantity,
	  Sum(log_wrh_shelf_contents.R_ReservedQuantity) As ReservedQuantity,
	  Sum(log_wrh_shelf_contents.R_FreeQuantity) As FreeQuantity,
	  log_wrh_shelf_contents.Product_RefID
	From
	  log_wrh_shelf_contents
	Where
	  log_wrh_shelf_contents.IsDeleted = 0 And
	  log_wrh_shelf_contents.Product_RefID = @ProductIDList
	Group By
	  log_wrh_shelf_contents.Product_RefID
  