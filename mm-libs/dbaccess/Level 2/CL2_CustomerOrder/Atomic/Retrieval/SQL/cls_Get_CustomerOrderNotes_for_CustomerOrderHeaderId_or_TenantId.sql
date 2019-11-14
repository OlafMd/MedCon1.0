
	SELECT
	  ord_cuo_customerorder_notes.ORD_CUO_CustomerOrder_NoteID,
	  ord_cuo_customerorder_notes.CustomerOrder_Header_RefID,
	  ord_cuo_customerorder_notes.CustomerOrder_Position_RefID,
      ord_cuo_customerorder_notes.CMN_BPT_CTM_OrganizationalUnit_RefID,
	  ord_cuo_customerorder_notes.Title,
	  ord_cuo_customerorder_notes.Comment,
	  ord_cuo_customerorder_notes.NotePublishDate,
	  ord_cuo_customerorder_notes.Creation_Timestamp,
	  ord_cuo_customerorder_notes.CreatedBy_BusinessParticipant_RefID,
	  cmn_bpt_businessparticipants.DisplayName AS CreatedBy
	FROM ord_cuo_customerorder_notes
	LEFT JOIN cmn_bpt_businessparticipants
	  ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = ord_cuo_customerorder_notes.CreatedBy_BusinessParticipant_RefID
	  AND cmn_bpt_businessparticipants.Tenant_RefID = ord_cuo_customerorder_notes.Tenant_RefID
	  AND cmn_bpt_businessparticipants.IsDeleted = ord_cuo_customerorder_notes.IsDeleted
	WHERE
	  (@CustomerOrderHeaderID IS NULL OR ord_cuo_customerorder_notes.CustomerOrder_Header_RefID = @CustomerOrderHeaderID)
	  AND ord_cuo_customerorder_notes.Tenant_RefID = @TenantID
	  AND ord_cuo_customerorder_notes.IsDeleted = 0;
  