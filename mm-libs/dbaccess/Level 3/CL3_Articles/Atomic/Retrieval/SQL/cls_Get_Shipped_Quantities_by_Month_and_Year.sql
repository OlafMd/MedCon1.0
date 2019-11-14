
	SELECT
		x.ProductID,
		x.MonthOfSale,
		x.YearOfSale,
		SUM(x.Quantity) AS SoldQuantity
	FROM
	(
		SELECT
			log_shp_shipment_positions.CMN_PRO_Product_RefID AS ProductID,
			(log_shp_shipment_positions.QuantityToShip) AS Quantity,
			EXTRACT(MONTH FROM log_shp_shipment_statushistory.Creation_Timestamp) AS MonthOfSale,
			EXTRACT(YEAR FROM log_shp_shipment_statushistory.Creation_Timestamp) AS YearOfSale
		FROM
			log_shp_shipment_headers
		INNER JOIN log_shp_shipment_statushistory
			ON log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
			AND log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID = @ShippedStatusID
			AND log_shp_shipment_statushistory.IsDeleted = 0
			AND log_shp_shipment_statushistory.Tenant_RefID = @TenantID
		INNER JOIN log_shp_shipment_positions
			ON log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
			AND log_shp_shipment_positions.IsDeleted = 0
			AND log_shp_shipment_positions.IsCancelled = 0
			AND log_shp_shipment_positions.CMN_PRO_Product_RefID = @ProductID_List
			AND log_shp_shipment_positions.Tenant_RefID = @TenantID
		WHERE
			log_shp_shipment_headers.IsDeleted = 0
			AND log_shp_shipment_headers.IsShipped = 1
			AND log_shp_shipment_headers.IsCustomerReturnShipment = 0
			AND log_shp_shipment_headers.Tenant_RefID = @TenantID
	) x 
	 GROUP BY 1,2,3

  