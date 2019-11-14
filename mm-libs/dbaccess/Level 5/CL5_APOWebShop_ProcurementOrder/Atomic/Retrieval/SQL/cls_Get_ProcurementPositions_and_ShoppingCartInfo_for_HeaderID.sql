
        SELECT
            ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID,
            ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID,
            ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID,
            ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID,
            ord_prc_procurementorder_positions.Position_Quantity,
            ord_prc_procurementorder_positions.Position_ValuePerUnit,
            ord_prc_procurementorder_positions.Position_ValueTotal,
            ord_prc_procurementorder_positions.IsProductReplacementAllowed,
            ord_prc_procurementorder_positions.CMN_PRO_Product_RefID,
            ord_prc_procurementorder_positions.CMN_PRO_Product_Variant_RefID,
            ord_prc_procurementorder_positions.CMN_PRO_Product_Release_RefID,
            cmn_str_offices.CMN_STR_OfficeID, 
            cmn_str_offices.Office_InternalNumber
        FROM
            ord_prc_procurementorder_positions 
        INNER JOIN ord_prc_shoppingcart_2_procurementorderposition
            ON ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID = ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID 
            AND ord_prc_shoppingcart_2_procurementorderposition.IsDeleted = 0 
        INNER JOIN ord_prc_shoppingcart_products
            ON ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ShoppingCart_Product_RefID = ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID 
            AND ord_prc_shoppingcart_products.IsDeleted = 0 
            AND ord_prc_shoppingcart_products.IsCanceled = 0
        INNER JOIN ord_prc_office_shoppingcarts
            ON ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID = ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID
            AND ord_prc_office_shoppingcarts.IsDeleted = 0
        LEFT JOIN cmn_str_offices
            ON cmn_str_offices.CMN_STR_OfficeID = ord_prc_office_shoppingcarts.CMN_STR_Office_RefID
            AND cmn_str_offices.IsDeleted = 0
        WHERE
            ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = @ProcurementOrderHeaderID 
            AND ord_prc_procurementorder_positions.IsDeleted = 0 
            AND ord_prc_procurementorder_positions.Tenant_RefID = @TenantID;
  