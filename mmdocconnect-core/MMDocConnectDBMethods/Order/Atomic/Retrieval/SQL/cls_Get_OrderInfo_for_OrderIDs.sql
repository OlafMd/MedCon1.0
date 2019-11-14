
    Select
      hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As patient_fee_waived,
      hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As label_only,
      ord_prc_procurementorder_positions.BillTo_BusinessParticipant_RefID As bill_to_bpt,
      ord_prc_procurementorder_notes.Comment As header_comment,
      ord_prc_procurementorder_positions.Position_Comment As position_comment,
      ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID as order_id
    From
      ord_prc_procurementorder_positions Inner Join
      hec_prc_procurementorder_positions
        On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID = hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID And
        hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        hec_prc_procurementorder_positions.IsDeleted = 0 Left Join
      ord_prc_procurementorder_notes
        On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Header_RefID And    
 	     ord_prc_procurementorder_notes.Title = 'Order comment' And
 	     ord_prc_procurementorder_notes.Tenant_RefID = @TenantID And
 	     ord_prc_procurementorder_notes.IsDeleted = 0
    Where
	    ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = @HeaderIDs And
	    ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
	    ord_prc_procurementorder_positions.IsDeleted = 0
  