
	SELECT
		log_producttrackinginstances.LOG_ProductTrackingInstanceID,
		log_producttrackinginstances.SerialNumber,
		log_producttrackinginstances.BatchNumber,
		log_producttrackinginstances.CMN_PRO_Product_RefID,
		log_producttrackinginstances.CurrentQuantityOnTrackingInstance
	FROM log_producttrackinginstances
		INNER JOIN log_wrh_shelfcontent_2_trackinginstance ON log_producttrackinginstances.LOG_ProductTrackingInstanceID = log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
		AND log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0
		AND log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
	WHERE
		log_producttrackinginstances.IsDeleted = 0
		AND log_producttrackinginstances.Tenant_RefID = @TenantID
		AND log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID = @ShelfContentID
  