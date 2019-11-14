
	Select
	  Sum(log_wrh_shelf_contents.Quantity_Current) as CurrentQuantity,
	  Sum(log_wrh_shelf_contents.Quantity_Initial) as InitialQuantity,
	  Sum(log_wrh_shelf_contents.R_FreeQuantity) as FreeQuantity,
	  Sum(log_wrh_shelf_contents.R_ReservedQuantity) as ReservedQuantity
	From
	  log_wrh_shelf_contents
	Where
	  log_wrh_shelf_contents.IsDeleted = 0 And
	  log_wrh_shelf_contents.Tenant_RefID = @TenantID And
	  log_wrh_shelf_contents.Product_RefID = @ProductID And
	  log_wrh_shelf_contents.Product_Variant_RefID = @ProductVariantID
	Group By
	  log_wrh_shelf_contents.Product_RefID,
	  log_wrh_shelf_contents.Product_Variant_RefID
  