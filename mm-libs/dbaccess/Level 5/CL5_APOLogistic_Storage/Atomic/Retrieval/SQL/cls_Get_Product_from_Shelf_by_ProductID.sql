
	SELECT 
		log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
    ,log_producttrackinginstances.LOG_ProductTrackingInstanceID
	FROM log_wrh_shelf_contents
	INNER JOIN log_wrh_shelfcontent_2_trackinginstance ON log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID = log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID
		AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
		AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
	INNER JOIN log_producttrackinginstances ON log_producttrackinginstances.LOG_ProductTrackingInstanceID = log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
		AND log_producttrackinginstances.IsDeleted = 0
		AND log_producttrackinginstances.Tenant_RefID = @TenantID
		AND log_producttrackinginstances.BatchNumber = @BatchNumber
		AND log_producttrackinginstances.ExpirationDate = @ExparationDate
	WHERE log_wrh_shelf_contents.Tenant_RefID = @TenantID
		AND log_wrh_shelf_contents.Product_RefID = @ProductID
		AND log_wrh_shelf_contents.IsDeleted = 0
		AND log_wrh_shelf_contents.Shelf_RefID = @ShelfID
  