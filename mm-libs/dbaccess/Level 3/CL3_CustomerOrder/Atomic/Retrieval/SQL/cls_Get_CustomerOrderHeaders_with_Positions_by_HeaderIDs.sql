
    SELECT
      ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
      ord_cuo_customerorder_headers.CustomerOrder_Number,
      ord_cuo_customerorder_headers.CustomerOrder_Date,
      ord_cuo_customerorder_headers.TotalValue_BeforeTax,
      ord_cuo_customerorder_headers.IsCustomerOrderFinalized,
      Order_CreatedBy.DisplayName AS OrderCreatedBy,
      Order_OrderedBy.IfCompany_CMN_COM_CompanyInfo_RefID AS OrderedByCompanyInfoId,
      cmn_universalcontactdetails.CompanyName_Line1 AS OrderedByCompanyName,
      cmn_universalcontactdetails.Contact_Email AS OrderedByEmail,
      ord_cuo_customerorder_statuses.Status_Code,
      ord_cuo_customerorder_statuses.Status_Name_DictID,
      ord_cuo_customerorder_statuses.GlobalPropertyMatchingID,
      Order_PerformedBy.DisplayName AS ConfirmedBy_DisplayName,
      ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
      ord_cuo_customerorder_positions.CMN_PRO_Product_RefID,
      ord_cuo_customerorder_positions.Position_ValueTotal,
      ord_cuo_customerorder_positions.Position_ValuePerUnit,
      ord_cuo_customerorder_positions.Position_Quantity,
      cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID,
      acc_tax_taxes.TaxRate,
      acc_tax_taxes.TaxName_DictID,
      acc_tax_taxes.EconomicRegion_RefID,
      cmn_pro_products.Product_Name_DictID,
      cmn_pro_products.Product_Number
    FROM ord_cuo_customerorder_headers
    INNER JOIN cmn_bpt_businessparticipants AS Order_OrderedBy
      ON Order_OrderedBy.CMN_BPT_BusinessParticipantID = ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID
      AND Order_OrderedBy.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND Order_OrderedBy.IsDeleted = 0
    INNER JOIN cmn_com_companyinfo
      ON cmn_com_companyinfo.CMN_COM_CompanyInfoID = Order_OrderedBy.IfCompany_CMN_COM_CompanyInfo_RefID
      AND cmn_com_companyinfo.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND cmn_com_companyinfo.IsDeleted = 0
    INNER JOIN cmn_universalcontactdetails
      ON cmn_universalcontactdetails.CMN_UniversalContactDetailID = cmn_com_companyinfo.Contact_UCD_RefID
      AND cmn_universalcontactdetails.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND cmn_universalcontactdetails.IsDeleted = 0
    INNER JOIN cmn_bpt_businessparticipants AS Order_CreatedBy
      ON Order_createdBy.CMN_BPT_BusinessParticipantID = ord_cuo_customerorder_headers.CreatedBy_BusinessParticipant_RefID
      AND Order_createdBy.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND Order_createdBy.IsDeleted = 0
    INNER JOIN ord_cuo_customerorder_statuses
      ON ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID = ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID
      AND ord_cuo_customerorder_statuses.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND ord_cuo_customerorder_statuses.IsDeleted = 0
    INNER JOIN ord_cuo_customerorder_statushistory
      ON ord_cuo_customerorder_statushistory.CustomerOrder_Status_RefID = ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID
      AND ord_cuo_customerorder_statushistory.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND ord_cuo_customerorder_statushistory.IsDeleted = 0
    LEFT JOIN cmn_bpt_businessparticipants AS Order_PerformedBy
      ON Order_PerformedBy.CMN_BPT_BusinessParticipantID = ord_cuo_customerorder_statushistory.PerformedBy_BusinessParticipant_RefID
      AND Order_PerformedBy.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND Order_PerformedBy.IsDeleted = 0
    LEFT JOIN ord_cuo_customerorder_positions
      ON ord_cuo_customerorder_positions.CustomerOrder_Header_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID
      AND ord_cuo_customerorder_positions.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND ord_cuo_customerorder_positions.IsDeleted = 0
    LEFT JOIN cmn_pro_products
      ON cmn_pro_products.CMN_PRO_ProductID = ord_cuo_customerorder_positions.CMN_PRO_Product_RefID
      AND cmn_pro_products.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND cmn_pro_products.IsDeleted = 0
    LEFT JOIN cmn_pro_product_salestaxassignmnets
      ON cmn_pro_product_salestaxassignmnets.Product_RefID = cmn_pro_products.CMN_PRO_ProductID
      AND cmn_pro_product_salestaxassignmnets.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND cmn_pro_product_salestaxassignmnets.IsDeleted = 0
    LEFT JOIN acc_tax_taxes
      ON acc_tax_taxes.ACC_TAX_TaxeID = cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
      AND acc_tax_taxes.Tenant_RefID = ord_cuo_customerorder_headers.Tenant_RefID
      AND acc_tax_taxes.IsDeleted = 0
    WHERE
      ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID = @CustomerOrderHeaderIDs
      AND ord_cuo_customerorder_headers.Tenant_RefID = @TenantID
      AND ord_cuo_customerorder_headers.IsDeleted = 0
      AND Order_OrderedBy.IsCompany = 1;
  