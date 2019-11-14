
Select Distinct
  ord_prc_procurementorder_positions.CMN_PRO_Product_RefID As ProductID
From
  ord_prc_expecteddelivery_positions Inner Join
  ord_prc_expecteddelivery_2_procurementorderposition
    On
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ExpectedDelivery_Position_RefID = ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_PositionID And ord_prc_expecteddelivery_2_procurementorderposition.IsDeleted = 0 And ord_prc_expecteddelivery_2_procurementorderposition.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_positions
    On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID =
    ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID And ord_prc_procurementorder_positions.IsDeleted = 0 And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And ord_prc_procurementorder_positions.CMN_PRO_Product_RefID = @ProductIDList Inner Join
  ord_prc_expecteddelivery_headers
    On ord_prc_expecteddelivery_positions.ORD_PRC_ExpectedDelivery_RefID =
    ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID And
    ord_prc_expecteddelivery_headers.IsDeleted = 0
    And ord_prc_expecteddelivery_headers.Tenant_RefID = @TenantID
Where
  ord_prc_expecteddelivery_headers.IsDeliveryOpen = 1
  