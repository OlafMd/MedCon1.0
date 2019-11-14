
      SELECT
        log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
        log_shp_shipment_positions.CMN_PRO_Product_RefID,
        log_shp_shipment_positions.QuantityToShip,
        log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
        cmn_currencies.Symbol AS CurrencySymbol,
        log_wrh_warehouses.Warehouse_Name,
        SUM(log_wrh_shelf_contents.Quantity_Current) AS QuantityInStock,
        SUM(hec_patient_prescription_positions.HEC_Patient_Prescription_PositionID) AS PrescriptionsCount
      FROM log_shp_shipment_positions
      
      INNER JOIN log_shp_shipment_headers
        ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
        AND log_shp_shipment_headers.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND log_shp_shipment_headers.IsDeleted = log_shp_shipment_positions.IsDeleted

      LEFT JOIN cmn_currencies
        ON cmn_currencies.CMN_CurrencyID = log_shp_shipment_headers.ShipmentHeader_Currency_RefID
        AND cmn_currencies.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND cmn_currencies.IsDeleted = log_shp_shipment_positions.IsDeleted

      LEFT JOIN log_wrh_warehouses
        ON log_wrh_warehouses.LOG_WRH_WarehouseID = log_shp_shipment_headers.Source_Warehouse_RefID
        AND log_wrh_warehouses.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND log_wrh_warehouses.IsDeleted = log_shp_shipment_positions.IsDeleted
    
      LEFT JOIN log_wrh_shelf_contents
        ON log_wrh_shelf_contents.Product_RefID = log_shp_shipment_positions.CMN_PRO_Product_RefID
        AND log_wrh_shelf_contents.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND log_wrh_shelf_contents.IsDeleted = log_shp_shipment_positions.IsDeleted
        
      LEFT JOIN ord_cuo_customerorder_position_2_shipmentposition
        ON ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
        AND ord_cuo_customerorder_position_2_shipmentposition.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = log_shp_shipment_positions.IsDeleted
      LEFT JOIN hec_patient_prescription_positions
        ON hec_patient_prescription_positions.BoundTo_CustomerOrderPosition_RefID = ord_cuo_customerorder_position_2_shipmentposition.ORD_CUO_CustomerOrder_Position_RefID
        AND hec_patient_prescription_positions.Tenant_RefID = log_shp_shipment_positions.Tenant_RefID
        AND hec_patient_prescription_positions.IsDeleted = log_shp_shipment_positions.IsDeleted
        
      WHERE
        log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderID
        AND log_shp_shipment_positions.Tenant_RefID = @TenantID
        AND log_shp_shipment_positions.IsDeleted = 0
      GROUP BY
        log_shp_shipment_positions.LOG_SHP_Shipment_PositionID;
  