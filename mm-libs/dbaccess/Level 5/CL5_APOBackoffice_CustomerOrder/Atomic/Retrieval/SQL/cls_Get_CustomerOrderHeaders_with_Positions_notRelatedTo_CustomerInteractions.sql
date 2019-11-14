
    SELECT
      ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
      Order_OrderedBy.IfCompany_CMN_COM_CompanyInfo_RefID,
      ord_cuo_customerorder_headers.CustomerOrder_Number,
      cmn_universalcontactdetails.CompanyName_Line1 AS OrderedByCompanyName,
      cmn_universalcontactdetails.Contact_Email AS OrderedByEmail,
      ord_cuo_customerorder_headers.CustomerOrder_Date,
      ord_cuo_customerorder_headers.TotalValue_BeforeTax,
      ord_cuo_customerorder_statuses.Status_Code,
      ord_cuo_customerorder_statuses.Status_Name_DictID,
      ord_cuo_customerorder_statuses.GlobalPropertyMatchingID,
      Order_createdBy.DisplayName AS OrderCreatedBy,
      cmn_pro_products.Product_Name_DictID,
      ord_cuo_customerorder_positions.CustomerOrder_Header_RefID,
      cmn_pro_products.Product_Number,
      cmn_pro_pac_packageinfo.PackageContent_Amount,
      cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID,
      hec_product_dosageforms.DosageForm_Name_DictID,
      cmn_units.Abbreviation_DictID,
      cmn_units.Label_DictID,
      ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
      ord_cuo_customerorder_positions.Position_Quantity,
      ord_cuo_customerorder_positions.Position_ValuePerUnit,
      ord_cuo_customerorder_positions.Position_ValueTotal,
      acc_tax_taxes.TaxRate,
      acc_tax_taxes.TaxName_DictID,
      acc_tax_taxes.EconomicRegion_RefID,
      cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID,
      ord_cuo_customerorder_headers.IsCustomerOrderFinalized,
      ord_cuo_customerorder_statushistory.PerformedBy_BusinessParticipant_RefID,
      bp1.DisplayName AS ConfirmedBy_DisplayName
    FROM ord_cuo_customerorder_headers
      INNER JOIN cmn_bpt_businessparticipants AS Order_OrderedBy
        On ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID = Order_OrderedBy.CMN_BPT_BusinessParticipantID 
      INNER JOIN cmn_com_companyinfo
        On Order_OrderedBy.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID 
      INNER JOIN cmn_universalcontactdetails 
        On cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID 
      INNER JOIN cmn_bpt_businessparticipants Order_createdBy
        On ord_cuo_customerorder_headers.CreatedBy_BusinessParticipant_RefID = Order_createdBy.CMN_BPT_BusinessParticipantID 
      LEFT JOIN ord_cuo_customerorder_positions
        On ord_cuo_customerorder_positions.CustomerOrder_Header_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID 
        And ord_cuo_customerorder_positions.Tenant_RefID = @TenantID 
        And ord_cuo_customerorder_positions.IsDeleted = 0 
      LEFT JOIN cmn_pro_products 
        On ord_cuo_customerorder_positions.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID 
        And cmn_pro_products.IsDeleted = 0
      LEFT JOIN hec_products 
        On hec_products.Ext_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID 
      LEFT JOIN hec_product_dosageforms 
        On hec_product_dosageforms.HEC_Product_DosageFormID = hec_products.ProductDosageForm_RefID 
      LEFT JOIN cmn_pro_pac_packageinfo 
        On cmn_pro_products.PackageInfo_RefID = cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID 
      LEFT JOIN cmn_units 
        On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID = cmn_units.CMN_UnitID 
      LEFT JOIN cmn_pro_product_salestaxassignmnets 
        On cmn_pro_products.CMN_PRO_ProductID = cmn_pro_product_salestaxassignmnets.Product_RefID
      LEFT JOIN acc_tax_taxes 
        On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID = acc_tax_taxes.ACC_TAX_TaxeID 
      INNER JOIN ord_cuo_customerorder_statuses
        On ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID = ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID  
      INNER JOIN ord_cuo_customerorder_statushistory
        On ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID = ord_cuo_customerorder_statushistory.CustomerOrder_Status_RefID 
        And ord_cuo_customerorder_statushistory.CustomerOrder_Header_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID 
      LEFT JOIN cmn_bpt_businessparticipants As bp1 
        On bp1.CMN_BPT_BusinessParticipantID = ord_cuo_customerorder_statushistory.PerformedBy_BusinessParticipant_RefID
    WHERE
      Order_OrderedBy.IsCompany = True 
      AND ord_cuo_customerorder_headers.Tenant_RefID = @TenantID  
      AND ord_cuo_customerorder_headers.IsDeleted = 0
      AND ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID NOT IN 
        (SELECT 
          cmn_pos_customerinteractions.CustomerOrderHeader_RefID 
        FROM cmn_pos_customerinteractions 
        WHERE 
          cmn_pos_customerinteractions.CustomerOrderHeader_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID)
    ORDER BY
      ord_cuo_customerorder_headers.CustomerOrder_Date Desc
  