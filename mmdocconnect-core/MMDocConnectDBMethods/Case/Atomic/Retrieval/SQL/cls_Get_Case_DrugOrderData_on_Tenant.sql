
    Select
      ord_prc_procurementorder_statuses.Status_Code as order_status_code,
      hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID as hec_order_position_id,
      hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As is_patient_fee_waived,
      hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As is_label_only
    From
      hec_prc_procurementorder_positions Inner Join
      ord_prc_procurementorder_positions
        On hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And
        ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_positions.IsDeleted = 0
      Inner Join
      ord_prc_procurementorder_headers
        On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID And
        ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_headers.IsDeleted = 0 
          Inner Join
      ord_prc_procurementorder_statuses
        On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
        ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_statuses.IsDeleted = 0
    Where
      hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And
      hec_prc_procurementorder_positions.IsDeleted = 0
	