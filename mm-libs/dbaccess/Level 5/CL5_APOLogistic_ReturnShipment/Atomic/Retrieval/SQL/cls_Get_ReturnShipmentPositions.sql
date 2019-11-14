
    SELECT 
      log_shp_shipment_headers.ShipmentHeader_Number
      ,log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
      ,log_rcp_receipt_headers.DeliverySlip_Number
      ,log_rcp_receipt_headers.Creation_Timestamp DateOfReturnShipmentCreation
      ,acc_crn_receivedcreditnotes.DateOnCreditNote
      ,acc_crn_receivedcreditnotes.CreditNote_Number
      ,log_shp_shipment_statuses.GlobalPropertyMatchingID
      ,supplier.DisplayName Supplier
      ,lastUpdatedBy.DisplayName LastUpdatedBy
      ,log_shp_shipment_positions.QuantityToShip
      ,log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax
      ,log_shp_shipment_positions.CMN_PRO_Product_RefID
      ,log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
      ,log_shp_returnshipment_headers.LOG_SHP_ReturnShipment_HeaderID
    FROM log_shp_returnshipment_positions

    INNER JOIN log_shp_returnshipment_headers 
      ON log_shp_returnshipment_headers.LOG_SHP_ReturnShipment_HeaderID = log_shp_returnshipment_positions.ReturnShipment_Header_RefID
      AND log_shp_returnshipment_headers.IsDeleted = 0
    INNER JOIN log_shp_shipment_headers 
      ON log_shp_returnshipment_headers.Ext_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
      AND log_shp_shipment_headers.IsDeleted = 0
    INNER JOIN log_shp_shipment_statushistory 
      ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID
      AND log_shp_shipment_statushistory.IsDeleted = 0
    LEFT JOIN log_shp_returnshipment_position_2_receivablecreditnote 
      ON log_shp_returnshipment_position_2_receivablecreditnote.LOG_SHP_ReturnShipment_Position_RefID = log_shp_returnshipment_positions.LOG_SHP_ReturnShipment_PositionID
    LEFT JOIN log_shp_returnshipment_receivablecreditnote_positions 
      ON log_shp_returnshipment_position_2_receivablecreditnote.LOG_SHP_ReturnShipment_ReceivableCreditNotes_Position_RefID 
        = log_shp_returnshipment_receivablecreditnote_positions.LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID
    LEFT JOIN log_shp_returnshipment_receivablecreditnote_headers 
      ON log_shp_returnshipment_receivablecreditnote_positions.LOG_SHP_ReturnShipment_CreditNotes_Header_RefID
        = log_shp_returnshipment_receivablecreditnote_headers.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID
    LEFT JOIN acc_crn_receivedcreditnotes
      ON acc_crn_receivedcreditnotes.ACC_CRN_ReceivedCreditNoteID = log_shp_returnshipment_receivablecreditnote_headers.Ext_ACC_CRN_ReceivedCreditNote_RefID
      AND acc_crn_receivedcreditnotes.Tenant_RefID = log_shp_returnshipment_positions.Tenant_RefID
      AND acc_crn_receivedcreditnotes.IsDeleted = 0
    INNER JOIN LOG_RCP_Receipt_Positions 
      ON LOG_RCP_Receipt_Positions.LOG_RCP_Receipt_PositionID = log_shp_returnshipment_positions.ReturnProductOriginatedFromReceiptPosition_RefID
      AND LOG_RCP_Receipt_Positions.IsDeleted = 0
    INNER JOIN LOG_RCP_Receipt_Headers 
      ON LOG_RCP_Receipt_Headers.LOG_RCP_Receipt_HeaderID = LOG_RCP_Receipt_Positions.Receipt_Header_RefID
      AND LOG_RCP_Receipt_Headers.IsDeleted = 0
    INNER JOIN cmn_bpt_businessparticipants supplier 
      ON log_shp_shipment_headers.RecipientBusinessParticipant_RefID = supplier.CMN_BPT_BusinessParticipantID
      AND supplier.IsDeleted = 0
    INNER JOIN cmn_bpt_businessparticipants lastUpdatedBy 
      ON log_shp_shipment_statushistory.PerformedBy_BusinessParticipant_RefID = lastUpdatedBy.CMN_BPT_BusinessParticipantID
      AND lastUpdatedBy.IsDeleted = 0
    INNER JOIN log_shp_shipment_positions 
      ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = log_shp_returnshipment_positions.Ext_Shipment_Position_RefID
      AND log_shp_shipment_positions.IsDeleted = 0
      AND log_shp_shipment_positions.IsCancelled = 0
    INNER JOIN (
        SELECT  
          log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID,
          max(log_shp_shipment_statushistory.Creation_Timestamp) as MaxDate
        FROM log_shp_shipment_statushistory
        GROUP BY
          log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID
      ) AS StatusHistory
      ON StatusHistory.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
      AND StatusHistory.MaxDate = log_shp_shipment_statushistory.Creation_Timestamp
    INNER JOIN log_shp_shipment_statuses
      ON log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID = log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID

    WHERE
      log_shp_returnshipment_positions.Tenant_RefID = @TenantID
      AND log_shp_returnshipment_positions.IsDeleted = 0
      AND log_shp_shipment_headers.IsCustomerReturnShipment = 0
      AND (@SupplierName IS NULL 
          OR LENGTH(@SupplierName) = 0
          OR LOWER(supplier.DisplayName) LIKE CONCAT('%', LOWER(@SupplierName), '%'))
      AND (@DeliverySlipNumber IS NULL 
          OR LENGTH(@DeliverySlipNumber) = 0
          OR LOWER(log_rcp_receipt_headers.DeliverySlip_Number) LIKE CONCAT('%', LOWER(@DeliverySlipNumber), '%'))
      AND (@ShipmentHeaderNr IS NULL 
          OR LENGTH(@ShipmentHeaderNr) = 0
          OR LOWER(log_shp_shipment_headers.ShipmentHeader_Number) LIKE CONCAT('%', LOWER(@ShipmentHeaderNr), '%'))
      AND log_shp_shipment_statuses.GlobalPropertyMatchingID = @Status
      AND (@RetShpCreationDateFrom IS NULL OR log_rcp_receipt_headers.Creation_Timestamp >= @RetShpCreationDateFrom)
      AND (@RetShpCreationDateTo IS NULL OR log_rcp_receipt_headers.Creation_Timestamp <= @RetShpCreationDateTo)  
      AND (@NoteCreationDateFrom IS NULL OR acc_crn_receivedcreditnotes.DateOnCreditNote >= @NoteCreationDateFrom)
      AND (@NoteCreationDateTo IS NULL OR acc_crn_receivedcreditnotes.DateOnCreditNote <= @NoteCreationDateTo) 
    GROUP BY 
      log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID, log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
  