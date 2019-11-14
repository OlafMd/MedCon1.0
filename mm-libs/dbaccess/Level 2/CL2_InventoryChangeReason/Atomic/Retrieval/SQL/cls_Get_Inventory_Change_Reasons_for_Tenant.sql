
	Select
	  log_wrh_inventorychangereasons.LOG_WRH_InventoryChangeReasonID,
	  log_wrh_inventorychangereasons.InventoryChange_Name_DictID,
	  log_wrh_inventorychangereasons.InventoryChange_Description_DictID,
	  log_wrh_inventorychangereasons.GlobalPropertyMatchingID
	From
	  log_wrh_inventorychangereasons
	Where
	  log_wrh_inventorychangereasons.IsDeleted = 0 And
	  log_wrh_inventorychangereasons.Tenant_RefID = @TenantID
  