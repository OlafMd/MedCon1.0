
      SELECT
		 log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
		 log_shp_shipment_headers.ShipmentHeader_Number,
		 log_shp_shipment_headers.Creation_Timestamp AS ShipmentHeader_Creation_Timestamp,
		 log_shp_shipment_statushistory_shipped.Creation_Timestamp AS StatusShipmentDate,
		 log_shp_shipment_headers.Creation_Timestamp AS OrderDate,
		 cmn_bpt_businessparticipants_customer.DisplayName AS CustomerName,
		 cmn_bpt_businessparticipants_customer.CMN_BPT_BusinessParticipantID AS CustomerBusinessParticipantID,
		 cmn_bpt_ctm_customers.InternalCustomerNumber,
		 cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
		 cmn_bpt_businessparticipants_creator.DisplayName AS CreatedByName,
		 log_shp_shipment_positions.CMN_PRO_Product_RefID,
		 log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
		 cmn_currencies.Symbol as CurrencySymbol,
		 acc_tax_taxes.TaxRate
	  FROM
		  log_shp_shipment_headers
	  INNER JOIN log_shp_shipment_positions ON log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
		AND log_shp_shipment_positions.IsDeleted = 0
		AND log_shp_shipment_positions.Tenant_RefID = @TenantID
	  INNER JOIN log_shp_shipment_statushistory log_shp_shipment_statushistory_created ON log_shp_shipment_statushistory_created.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
		AND log_shp_shipment_statushistory_created.LOG_SHP_Shipment_Status_RefID = @ShipmentStatusID_Created
		AND log_shp_shipment_statushistory_created.IsDeleted = 0
		AND log_shp_shipment_statushistory_created.Tenant_RefID = @TenantID
	  INNER JOIN cmn_bpt_businessparticipants as cmn_bpt_businessparticipants_creator ON 
		cmn_bpt_businessparticipants_creator.CMN_BPT_BusinessParticipantID = log_shp_shipment_statushistory_created.PerformedBy_BusinessParticipant_RefID
	  INNER JOIN cmn_bpt_businessparticipants cmn_bpt_businessparticipants_customer ON cmn_bpt_businessparticipants_customer.CMN_BPT_BusinessParticipantID = log_shp_shipment_headers.RecipientBusinessParticipant_RefID
		  AND cmn_bpt_businessparticipants_customer.Tenant_RefID = @TenantID
	  INNER JOIN cmn_bpt_ctm_customers ON
		cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = log_shp_shipment_headers.RecipientBusinessParticipant_RefID
		AND cmn_bpt_ctm_customers.IsDeleted = 0
		AND cmn_bpt_ctm_customers.Tenant_RefID = @TenantID
	  INNER JOIN log_shp_shipment_statushistory log_shp_shipment_statushistory_shipped ON log_shp_shipment_statushistory_shipped.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
		AND log_shp_shipment_statushistory_shipped.LOG_SHP_Shipment_Status_RefID = @ShipmentStatusID_Shipped
		AND log_shp_shipment_statushistory_shipped.IsDeleted = 0
		AND log_shp_shipment_statushistory_shipped.Tenant_RefID = @TenantID 
	  LEFT OUTER JOIN bil_billposition_2_shipmentposition ON bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
		AND bil_billposition_2_shipmentposition.IsDeleted = 0
		AND bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID
		LEFT JOIN cmn_sls_prices ON cmn_sls_prices.CMN_PRO_Product_RefID = log_shp_shipment_positions.CMN_PRO_Product_RefID AND cmn_sls_prices.IsDeleted = 0
		  AND cmn_sls_prices.IsDeleted = 0
		  AND cmn_sls_prices.Tenant_RefID = @TenantID
		LEFT JOIN cmn_currencies ON cmn_sls_prices.CMN_Currency_RefID = cmn_currencies.CMN_CurrencyID AND cmn_currencies.IsDeleted = 0
		  AND cmn_currencies.IsDeleted = 0
		  AND cmn_currencies.Tenant_RefID = @TenantID
		LEFT JOIN cmn_pro_product_salestaxassignmnets ON log_shp_shipment_positions.CMN_PRO_Product_RefID = cmn_pro_product_salestaxassignmnets.Product_RefID
		  AND cmn_pro_product_salestaxassignmnets.Tenant_RefID = @TenantID
		 LEFT JOIN acc_tax_taxes
		  ON cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID = acc_tax_taxes.ACC_TAX_TaxeID
		  AND acc_tax_taxes.Tenant_RefID = @TenantID
	  WHERE
		log_shp_shipment_headers.IsDeleted = 0
		AND log_shp_shipment_headers.IsShipped = 1
		AND log_shp_shipment_headers.IsBilled = 0
		AND log_shp_shipment_headers.Tenant_RefID = @TenantID
		AND bil_billposition_2_shipmentposition.AssignmentID IS NULL
		AND (@OrderNumber IS NULL OR (@OrderNumber IS NOT NULL AND log_shp_shipment_headers.ShipmentHeader_Number LIKE CONCAT('%', @OrderNumber, '%')))
		AND (@Customer IS NULL OR (@Customer IS NOT NULL AND LOWER(cmn_bpt_businessparticipants_customer.DisplayName) LIKE LOWER(CONCAT('%', @Customer, '%'))))
		AND (@PeriodFrom IS NULL OR (@PeriodFrom IS NOT NULL AND log_shp_shipment_headers.Creation_Timestamp >= @PeriodFrom))
		AND (@PeriodTo IS NULL OR (@PeriodTo IS NOT NULL AND log_shp_shipment_headers.Creation_Timestamp <= @PeriodTo))
		AND (@DeliveryFrom IS NULL OR (@DeliveryFrom IS NOT NULL AND log_shp_shipment_statushistory_shipped.Creation_Timestamp >= @DeliveryFrom))
		AND (@DeliveryTo IS NULL OR (@DeliveryTo IS NOT NULL AND log_shp_shipment_statushistory_shipped.Creation_Timestamp <= @DeliveryTo))

  

  