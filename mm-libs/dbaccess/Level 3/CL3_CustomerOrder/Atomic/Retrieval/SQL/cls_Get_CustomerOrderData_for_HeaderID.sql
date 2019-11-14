
	Select
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Date,
  ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID As
  CustomerId,
  cmn_bpt_businessparticipants.DisplayName As CustomerName,
  log_wrh_warehouses.Warehouse_Name,
  ord_cuo_customerorder_headers.DeliveryDeadline,
  ord_cuo_customerorder_headers.Creation_Timestamp
From
  ord_cuo_customerorder_headers Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.Tenant_RefID =
    ord_cuo_customerorder_headers.Tenant_RefID And
    cmn_bpt_businessparticipants.IsDeleted =
    ord_cuo_customerorder_headers.IsDeleted Left Join
  log_wrh_warehouses On log_wrh_warehouses.LOG_WRH_WarehouseID =
    ord_cuo_customerorder_headers.DeliveryRequestedFrom_Warehouse_RefID And
    log_wrh_warehouses.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
    And log_wrh_warehouses.IsDeleted = ord_cuo_customerorder_headers.IsDeleted
Where
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
  @CustomerOrderHeaderID And
  ord_cuo_customerorder_headers.Tenant_RefID = @TenantID And
  ord_cuo_customerorder_headers.IsDeleted = 0
  