
  Select
    log_shp_shipment_notes.LOG_SHP_Shipment_NoteID,
    log_shp_shipment_notes.Shipment_Header_RefID,
    log_shp_shipment_notes.Shipment_Position_RefID,
    log_shp_shipment_notes.IsNotePrintedOnDeliveryPaper,
    log_shp_shipment_notes.Title,
    log_shp_shipment_notes.Comment,
    log_shp_shipment_notes.NotePublishDate,
    log_shp_shipment_notes.SequenceOrderNumber,
    log_shp_shipment_notes.Creation_Timestamp,
    log_shp_shipment_notes.Tenant_RefID,
    log_shp_shipment_notes.IsDeleted,
    cmn_bpt_businessparticipants.DisplayName As CreatedBy,
    log_shp_shipment_notes.CreatedBy_BusinessParticipant_RefID
  From
    log_shp_shipment_notes Left Join
    cmn_bpt_businessparticipants
      On log_shp_shipment_notes.CreatedBy_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    log_shp_shipment_notes.Shipment_Header_RefID = @ShipmentHeaderID And
    log_shp_shipment_notes.Tenant_RefID = @TenantID And
    log_shp_shipment_notes.IsDeleted = 0
  