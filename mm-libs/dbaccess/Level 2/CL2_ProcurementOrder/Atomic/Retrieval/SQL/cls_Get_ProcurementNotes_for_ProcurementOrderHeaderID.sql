
	SELECT ord_prc_procurementorder_notes.SequenceOrderNumber
		,ord_prc_procurementorder_notes.NotePublishDate
		,ord_prc_procurementorder_notes.Title
		,ord_prc_procurementorder_notes.Comment
		,ord_prc_procurementorder_notes.CMN_STR_Office_RefID
		,ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_NoteID
    ,ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Header_RefID
    ,ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Position_RefID
    ,ord_prc_procurementorder_notes.Creation_Timestamp
	FROM ord_prc_procurementorder_notes
	INNER JOIN ord_prc_procurementorder_headers ON ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
		AND ord_prc_procurementorder_headers.IsDeleted = 0
		AND ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
		AND ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID = @HeaderID
	WHERE ord_prc_procurementorder_notes.IsDeleted = 0
		AND ord_prc_procurementorder_notes.Tenant_RefID = @TenantID
  