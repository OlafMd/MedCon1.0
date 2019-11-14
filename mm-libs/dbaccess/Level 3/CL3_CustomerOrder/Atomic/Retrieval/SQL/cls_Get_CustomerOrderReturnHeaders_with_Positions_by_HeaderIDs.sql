
      SELECT 
        X.*,
        SUM(X.Quantity_Current) AS QuantityInStock
      FROM (  
        SELECT
          ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID,
          ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber,
          ord_cuo_customerorderreturn_headers.DateOfCustomerReturn,
          ord_cuo_customerorderreturn_headers.TotalValueBeforeTax AS CustomerOrderReturnHeaderTotalValue,
          ReturnOrder_CreatedBy.DisplayName AS ReturnOrderCreatedBy,
          ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID,
          ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID,
          ord_cuo_customerorderreturn_positions.Position_ValueTotal,
          ord_cuo_customerorderreturn_positions.Position_ValuePerUnit,
          ord_cuo_customerorderreturn_positions.Position_Quantity,
          cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID,
          acc_tax_taxes.TaxRate,
          acc_tax_taxes.TaxName_DictID,
          acc_tax_taxes.EconomicRegion_RefID,
          cmn_pro_products.Product_Name_DictID,
          cmn_pro_products.Product_Number,
          cmn_pro_products.IsStorage_BatchNumberMandatory,
          cmn_pro_products.IsStorage_ExpiryDateMandatory,
          log_wrh_shelf_contents.Quantity_Current,
          ReturnOrder_Customer.DisplayName AS CustomerName,
          log_rcp_receipt_position_qualitycontrolitems.BatchNumber,
          log_rcp_receipt_position_qualitycontrolitems.ExpiryDate,
          log_rcp_receipt_position_qualitycontrolitems.Target_WRH_Shelf_RefID
        FROM ord_cuo_customerorderreturn_headers
        LEFT JOIN cmn_bpt_businessparticipants AS ReturnOrder_CreatedBy
          ON ReturnOrder_CreatedBy.CMN_BPT_BusinessParticipantID = ord_cuo_customerorderreturn_headers.CreatedBy_BusinessParticipant_RefID
          AND ReturnOrder_CreatedBy.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND ReturnOrder_CreatedBy.IsDeleted = 0
        LEFT JOIN ord_cuo_customerorderreturn_positions
          ON ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID = ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID
          AND ord_cuo_customerorderreturn_positions.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND ord_cuo_customerorderreturn_positions.IsDeleted = 0
        LEFT JOIN cmn_pro_products
          ON cmn_pro_products.CMN_PRO_ProductID = ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID
          AND cmn_pro_products.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND cmn_pro_products.IsDeleted = 0
        LEFT JOIN cmn_pro_product_salestaxassignmnets
          ON cmn_pro_product_salestaxassignmnets.Product_RefID = cmn_pro_products.CMN_PRO_ProductID
          AND cmn_pro_product_salestaxassignmnets.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND cmn_pro_product_salestaxassignmnets.IsDeleted = 0
        LEFT JOIN acc_tax_taxes
          ON acc_tax_taxes.ACC_TAX_TaxeID = cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
          AND acc_tax_taxes.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND acc_tax_taxes.IsDeleted = 0
        LEFT JOIN log_wrh_shelf_contents
          ON log_wrh_shelf_contents.Product_RefID = ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID
          AND log_wrh_shelf_contents.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND log_wrh_shelf_contents.IsDeleted = 0
        LEFT JOIN cmn_bpt_ctm_customers
          ON cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID = ord_cuo_customerorderreturn_headers.Customer_RefID
          AND cmn_bpt_ctm_customers.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND cmn_bpt_ctm_customers.IsDeleted = 0
        LEFT JOIN cmn_bpt_businessparticipants AS ReturnOrder_Customer
          ON ReturnOrder_Customer.CMN_BPT_BusinessParticipantID = cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID
          AND ReturnOrder_Customer.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND ReturnOrder_Customer.IsDeleted = 0
        LEFT JOIN log_rcp_receipt_positions
		  ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = ord_cuo_customerorderreturn_positions.CorrespondingReceiptPosition_RefID
          AND log_rcp_receipt_positions.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND log_rcp_receipt_positions.IsDeleted = 0
        LEFT JOIN log_rcp_receipt_position_qualitycontrolitems
		  ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID
          AND log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
          AND log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0
        WHERE
          ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID = @CustomerOrderReturnHeaderIDs
          AND ord_cuo_customerorderreturn_headers.Tenant_RefID = @TenantID
          AND ord_cuo_customerorderreturn_headers.IsDeleted = 0
      ) AS X
      GROUP BY X.ORD_CUO_CustomerOrderReturn_PositionID
  