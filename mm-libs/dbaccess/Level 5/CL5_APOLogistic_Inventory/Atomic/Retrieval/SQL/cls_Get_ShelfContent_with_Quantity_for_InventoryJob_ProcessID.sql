
SELECT log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_INJ_InventoryJob_Process_ShelfID
	,log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_Shelf_RefID
	,log_producttrackinginstances.LOG_ProductTrackingInstanceID
	,log_wrh_shelf_contents.Quantity_Current AS ShelfContent_Quantity
	,log_producttrackinginstances.CurrentQuantityOnTrackingInstance AS TrackingInstance_Quantity
	,log_producttrackinginstances.BatchNumber
	,log_producttrackinginstances.ExpirationDate
	,log_wrh_shelf_contents.Product_RefID
	,log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
	,log_wrh_shelves.CoordinateCode AS ShelfCode
	,log_wrh_shelves.Shelf_Name AS ShelfName
FROM log_wrh_inj_inventoryjob_process_shelves
INNER JOIN log_wrh_shelves ON log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_Shelf_RefID = log_wrh_shelves.LOG_WRH_ShelfID
	AND log_wrh_shelves.IsDeleted = 0
	AND log_wrh_shelves.Tenant_RefID = @TenantID
INNER JOIN log_wrh_shelf_contents ON log_wrh_shelf_contents.Shelf_RefID = log_wrh_shelves.LOG_WRH_ShelfID
	AND log_wrh_shelf_contents.IsDeleted = 0
	AND log_wrh_shelf_contents.Tenant_RefID = @TenantID
LEFT OUTER JOIN log_wrh_shelfcontent_2_trackinginstance ON log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID = log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
	AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
	AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
LEFT OUTER JOIN log_producttrackinginstances ON log_producttrackinginstances.LOG_ProductTrackingInstanceID = log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
	AND log_producttrackinginstances.IsDeleted = 0
	AND log_producttrackinginstances.Tenant_RefID = @TenantID
WHERE log_wrh_inj_inventoryjob_process_shelves.IsDeleted = 0
	AND log_wrh_inj_inventoryjob_process_shelves.Tenant_RefID = @TenantID
	AND log_wrh_inj_inventoryjob_process_shelves.LOG_WRH_INJ_InventoryJob_Process_RefID = @ProcessID
GROUP BY log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID

  