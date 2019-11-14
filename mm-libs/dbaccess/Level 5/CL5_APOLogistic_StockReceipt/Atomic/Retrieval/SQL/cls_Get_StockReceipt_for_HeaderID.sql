
    
    SELECT 
        log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID
        ,log_rcp_receipt_headers.ProvidingSupplier_RefID AS SupplierID
        ,ord_prc_expecteddelivery_headers.ExpectedDeliveryDate
        ,log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
        ,log_rcp_receipt_positions.TotalQuantityTakenIntoStock
        ,cmn_bpt_businessparticipants_supplier.DisplayName AS SupplierName
        ,cmn_pro_products.Product_Name_DictID
        ,cmn_pro_products.Product_Number
        ,hec_product_dosageforms.DosageForm_Name_DictID
        ,hec_product_dosageforms.GlobalPropertyMatchingID
        ,cmn_units.Abbreviation_DictID
        ,cmn_units.ISOCode
        ,cmn_pro_pac_packageinfo.PackageContent_Amount
        ,cmn_sls_prices.PriceAmount AS AEK_Price
        ,ord_prc_procurementorder_positions.Position_ValuePerUnit
        ,ord_prc_procurementorder_positions.Position_Quantity
        ,ord_prc_procurementorder_positions.Position_ValueTotal
        ,log_rcp_receipt_position_qualitycontrolitems.BatchNumber
        ,log_rcp_receipt_position_qualitycontrolitems.ExpiryDate
    FROM log_rcp_receipt_headers
    INNER JOIN ord_prc_expecteddelivery_headers ON ord_prc_expecteddelivery_headers.ORD_PRC_ExpectedDelivery_HeaderID = log_rcp_receipt_headers.ExpectedDeliveryHeader_RefID
        AND ord_prc_expecteddelivery_headers.Tenant_RefID = @TenantID
        AND ord_prc_expecteddelivery_headers.IsDeleted = 0    	
    LEFT OUTER JOIN log_rcp_receipt_positions ON log_rcp_receipt_positions.Receipt_Header_RefID = log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID
        AND log_rcp_receipt_positions.Tenant_RefID = @TenantID
        AND log_rcp_receipt_positions.IsDeleted = 0
    LEFT OUTER JOIN log_rcp_receiptposition_2_procurementorderposition ON log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID = log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID
        AND log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = @TenantID
        AND log_rcp_receiptposition_2_procurementorderposition.IsDeleted = 0
    LEFT OUTER JOIN ord_prc_procurementorder_positions ON log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
        AND ord_prc_procurementorder_positions.Tenant_RefID = @TenantID
        AND ord_prc_procurementorder_positions.IsDeleted = 0
    LEFT OUTER JOIN cmn_pro_products ON cmn_pro_products.CMN_PRO_ProductID = ord_prc_procurementorder_positions.CMN_PRO_Product_RefID
        AND cmn_pro_products.Tenant_RefID = @TenantID
        AND cmn_pro_products.IsDeleted = 0
        AND cmn_pro_products.IsProduct_Article = 1
    LEFT OUTER JOIN hec_products ON hec_products.Ext_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
        AND hec_products.Tenant_RefID = @TenantID
        AND hec_products.IsDeleted = 0
    LEFT OUTER JOIN cmn_pro_subscribedcatalogs ON 
        cmn_pro_subscribedcatalogs.CatalogCodeITL = 'abda-catalog'
        AND cmn_pro_subscribedcatalogs.IsDeleted = 0
        AND cmn_pro_subscribedcatalogs.Tenant_RefID = @TenantID
    LEFT OUTER JOIN cmn_sls_pricelist_releases ON cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID = cmn_pro_subscribedcatalogs.SubscribedCatalog_PricelistRelease_RefID
        AND cmn_sls_pricelist_releases.Tenant_RefID = @TenantID
        AND cmn_sls_pricelist_releases.IsDeleted = 0
    LEFT OUTER JOIN cmn_sls_prices ON cmn_sls_prices.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
        AND cmn_sls_prices.PricelistRelease_RefID = cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID
        AND cmn_sls_prices.Tenant_RefID = @TenantID
        AND cmn_sls_prices.IsDeleted = 0
    LEFT OUTER JOIN hec_product_dosageforms ON hec_products.ProductDosageForm_RefID = hec_product_dosageforms.HEC_Product_DosageFormID
        AND hec_product_dosageforms.Tenant_RefID = @TenantID
        AND hec_product_dosageforms.IsDeleted = 0
    LEFT OUTER JOIN cmn_pro_pac_packageinfo ON cmn_pro_products.PackageInfo_RefID = cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID
        AND cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID
        AND cmn_pro_pac_packageinfo.IsDeleted = 0
    LEFT OUTER JOIN cmn_units ON cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID = cmn_units.CMN_UnitID
        AND cmn_units.Tenant_RefID = @TenantID
        AND cmn_units.IsDeleted = 0
    LEFT OUTER JOIN log_rcp_receipt_position_qualitycontrolitems ON log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID = log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID
        AND log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID = @TenantID
        AND log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0
    LEFT OUTER JOIN cmn_bpt_suppliers ON cmn_bpt_suppliers.CMN_BPT_SupplierID = log_rcp_receipt_headers.ProvidingSupplier_RefID
        AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
        AND cmn_bpt_suppliers.IsDeleted = 0
    LEFT OUTER JOIN cmn_bpt_businessparticipants cmn_bpt_businessparticipants_supplier ON cmn_bpt_businessparticipants_supplier.CMN_BPT_BusinessParticipantID = cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
        AND cmn_bpt_businessparticipants_supplier.Tenant_RefID = @TenantID
        AND cmn_bpt_businessparticipants_supplier.IsDeleted = 0
    WHERE 
        log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = @HeaderID
        AND log_rcp_receipt_headers.Tenant_RefID = @TenantID
        AND log_rcp_receipt_headers.IsDeleted = 0


  