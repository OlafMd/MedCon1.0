

	Select
	  ord_prc_procurementorder_headers.ProcurementOrder_Number,
	  cmn_bpt_businessparticipants.DisplayName,
	  ord_prc_procurementorder_statuses.Status_Name_DictID,
	  ord_prc_expecteddelivery_positions.TotalExpectedQuantity,
	  ord_prc_expecteddelivery_headers.ExpectedDeliveryDate,
	  ord_prc_expecteddelivery_headers.IsDeliveryOpen
	From
	  ord_prc_procurementorder_positions Inner Join
	  ord_prc_procurementorder_headers
	    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
	    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
	    And ord_prc_procurementorder_headers.IsDeleted = 0 And
	    ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And
	    ord_prc_procurementorder_headers.IsCreatedForExpectedDelivery = 1 Inner Join
	  cmn_bpt_suppliers On cmn_bpt_suppliers.CMN_BPT_SupplierID =
	    ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID And
	    cmn_bpt_suppliers.IsDeleted = 0 And cmn_bpt_suppliers.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
	    cmn_bpt_suppliers.Ext_BusinessParticipant_RefID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Left Join
	  ord_prc_procurementorder_statuses
	    On ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID =
	    ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID And
	    ord_prc_procurementorder_statuses.IsDeleted = 0 And
	    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID Inner Join
	  ord_prc_expecteddelivery_2_procurementorderposition
	    On
	    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_expecteddelivery_2_procurementorderposition.IsDeleted = 0 And ord_prc_expecteddelivery_2_procurementorderposition.Tenant_RefID = @TenantID Inner Join
	  ord_prc_expecteddelivery_positions
	    On
	    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ExpectedDelivery_Position_RefID = ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID And ord_prc_expecteddelivery_positions.IsDeleted = 0 And ord_prc_expecteddelivery_positions.Tenant_RefID = @TenantID Inner Join
	  ord_prc_expecteddelivery_headers
	    On ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID =
	    ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_RefID And
	    ord_prc_expecteddelivery_headers.IsDeleted = 0 And
	    ord_prc_expecteddelivery_headers.Tenant_RefID = @TenantID
	Where
	  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID = @ProductID And
	  ord_prc_procurementorder_positions.IsDeleted = 0 And
	  ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
	  ord_prc_expecteddelivery_headers.IsDeliveryOpen = 1
  