
    Select
      hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As is_patient_fee_waived,
      hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As is_label_only,
      hec_prc_procurementorder_positions.Modification_Timestamp As order_modification_timestamp,
      ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_From As alternative_delivery_date_from,
      ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_To As alternative_delivery_date_to,
      ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery As delivery_date,
      ord_prc_procurementorder_positions.Position_Comment As order_comment,
      ord_prc_procurementorder_statuses.Status_Code as order_status_code
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
        ord_prc_procurementorder_headers.IsDeleted = 0 Inner Join
      ord_prc_procurementorder_statuses
        On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
        ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_statuses.IsDeleted = 0
    Where
      hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID = @OrderID And
      hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And
      hec_prc_procurementorder_positions.IsDeleted = 0
	