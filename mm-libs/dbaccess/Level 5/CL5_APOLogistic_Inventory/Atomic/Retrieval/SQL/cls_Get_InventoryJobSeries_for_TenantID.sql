
	Select
	  log_wrh_inj_inventoryjob_series.LOG_WRH_INJ_InventoryJob_SeriesID,
	  log_wrh_inj_inventoryjob_series.InventoryJobSeries_DisplayName,
	  log_wrh_inj_inventoryjob_series.Creation_Timestamp,
	  log_wrh_inj_inventoryjob_series_rythms.RythmCronExpression,
	  Count(log_wrh_inj_inventoryjob_series_participatingshelves.LOG_WRH_Shelf_RefID) As ShelfToCount,
	  log_wrh_inj_inventoryjob_series.NumberOfProductsToSelect As ArticlesToCount 
	From
	  log_wrh_inj_inventoryjob_series Left Join
	  log_wrh_inj_inventoryjob_series_rythms
	    On log_wrh_inj_inventoryjob_series.LOG_WRH_INJ_InventoryJob_SeriesID =
	    log_wrh_inj_inventoryjob_series_rythms.InventoryJob_Series_RefID And
	    log_wrh_inj_inventoryjob_series_rythms.Tenant_RefID = @TenantID And
	    log_wrh_inj_inventoryjob_series_rythms.IsDeleted = 0 Left Join
	  log_wrh_inj_inventoryjob_series_participatingshelves
	    On log_wrh_inj_inventoryjob_series.LOG_WRH_INJ_InventoryJob_SeriesID =
	    log_wrh_inj_inventoryjob_series_participatingshelves.LOG_WRH_INJ_InventoryJob_Series_RefID And log_wrh_inj_inventoryjob_series_participatingshelves.Tenant_RefID = @TenantID And log_wrh_inj_inventoryjob_series_participatingshelves.IsDeleted = 0
	Where
	  log_wrh_inj_inventoryjob_series.Tenant_RefID = @TenantID And
	  log_wrh_inj_inventoryjob_series.IsDeleted = 0
	Group By
	  log_wrh_inj_inventoryjob_series.LOG_WRH_INJ_InventoryJob_SeriesID
  