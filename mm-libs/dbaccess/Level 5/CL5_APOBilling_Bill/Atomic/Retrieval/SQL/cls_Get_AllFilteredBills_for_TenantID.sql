
    SELECT *
    FROM
    (
    SELECT
        COUNT(bil_billpositions.BIL_BillPositionID) AS NumberOfPositions,
        MAX(bil_billheader_2_billstatus.Creation_Timestamp) AS BillStatusCreationTime,
        log_shp_shipment_statushistory.Creation_Timestamp AS ShipmentStatusTime,
        bil_billheaders.TotalValue_BeforeTax AS TotalValueBeforeTax,
        bil_billheaders.TotalValue_IncludingTax AS TotalValueIncludingTax,
        bil_billstatuses.GlobalPropertyMatchingID AS BillStatusGlobalProperty,
        bil_billstatuses.BillStatus_Name_DictID,
        bil_billheaders.BIL_BillHeaderID,
        bil_billheaders.BillNumber,
        bil_billheaders.BillComment,
        bil_billheaders.DateOnBill,
        cmn_bpt_businessparticipants_creator.DisplayName AS CreatedByName,
        cmn_bpt_businessparticipants_billrecipient.DisplayName AS BillRecipientName,
        cmn_bpt_businessparticipants_customer.DisplayName AS CustomerName,
        cmn_bpt_ctm_customers.InternalCustomerNumber AS CustomerNumber,
        COALESCE(acc_pay_conditions.MaximumPaymentTreshold_InDays, 0) AS MaximumPaymentTreshold_InDays,
        acc_pay_conditions.ACC_PAY_ConditionID,
        bil_billheader_methodofpayments.ACC_PAY_Type_RefID,
        acc_dun_dunningprocess_memberbills.ACC_DUN_DunningProcess_MemberBillID,
        bil_billheaders.IsFullyPaid
    FROM bil_billheaders
    INNER JOIN bil_billheader_2_billstatus
        ON bil_billheader_2_billstatus.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
        AND bil_billheader_2_billstatus.IsDeleted = 0
        AND bil_billheader_2_billstatus.Tenant_RefID = @TenantID
        AND bil_billheader_2_billstatus.IsCurrentStatus = 1
    INNER JOIN bil_billstatuses
        ON bil_billstatuses.BIL_BillStatusID = bil_billheader_2_billstatus.BIL_BillStatus_RefID
        AND bil_billstatuses.IsDeleted = 0
        AND bil_billstatuses.Tenant_RefID = @TenantID
    LEFT OUTER JOIN bil_billpositions
        ON bil_billheaders.BIL_BillHeaderID = bil_billpositions.BIL_BilHeader_RefID
        AND bil_billpositions.IsDeleted = 0
        AND bil_billpositions.Tenant_RefID = @TenantID
    LEFT OUTER JOIN bil_billposition_2_shipmentposition
        ON bil_billposition_2_shipmentposition.BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID
        AND bil_billposition_2_shipmentposition.IsDeleted = 0
        AND bil_billposition_2_shipmentposition.Tenant_RefID = @TenantID
    LEFT OUTER JOIN log_shp_shipment_positions
        ON log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = bil_billposition_2_shipmentposition.LOG_SHP_Shipment_Position_RefID
        AND log_shp_shipment_positions.IsDeleted = 0
        AND log_shp_shipment_positions.Tenant_RefID = @TenantID
    LEFT OUTER JOIN log_shp_shipment_headers
        ON log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
        AND log_shp_shipment_headers.IsDeleted = 0
        AND log_shp_shipment_headers.IsShipped = 1
        AND log_shp_shipment_headers.IsBilled = 0
        AND log_shp_shipment_headers.Tenant_RefID = @TenantID
    LEFT OUTER JOIN log_shp_shipment_statushistory 
        ON log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID = log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
        AND log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID = @ShipmentStatusID
        AND log_shp_shipment_statushistory.IsDeleted = 0
        AND log_shp_shipment_statushistory.Tenant_RefID = @TenantID
    LEFT OUTER JOIN cmn_bpt_businessparticipants as cmn_bpt_businessparticipants_creator
        ON cmn_bpt_businessparticipants_creator.CMN_BPT_BusinessParticipantID = bil_billheaders.CreatedBy_BusinessParticipant_RefID
        AND cmn_bpt_businessparticipants_creator.IsDeleted = 0
        AND cmn_bpt_businessparticipants_creator.Tenant_RefID = @TenantID
    LEFT OUTER JOIN cmn_bpt_businessparticipants as cmn_bpt_businessparticipants_billrecipient
        ON cmn_bpt_businessparticipants_billrecipient.CMN_BPT_BusinessParticipantID = bil_billheaders.BillRecipient_BuisnessParticipant_RefID
        AND cmn_bpt_businessparticipants_billrecipient.IsDeleted = 0
        AND cmn_bpt_businessparticipants_billrecipient.Tenant_RefID = @TenantID
    LEFT OUTER JOIN cmn_bpt_ctm_customers
        ON cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = log_shp_shipment_headers.RecipientBusinessParticipant_RefID
        AND cmn_bpt_ctm_customers.IsDeleted = 0
        AND cmn_bpt_ctm_customers.Tenant_RefID = @TenantID
    LEFT OUTER JOIN cmn_bpt_businessparticipants as cmn_bpt_businessparticipants_customer
        ON cmn_bpt_businessparticipants_customer.CMN_BPT_BusinessParticipantID = log_shp_shipment_headers.RecipientBusinessParticipant_RefID
        AND cmn_bpt_businessparticipants_customer.IsDeleted = 0
        AND cmn_bpt_businessparticipants_customer.Tenant_RefID = @TenantID 
    LEFT OUTER JOIN acc_pay_conditions
        ON acc_pay_conditions.ACC_PAY_ConditionID = bil_billheaders.BillHeader_PaymentCondition_RefID
        AND acc_pay_conditions.Tenant_RefID = @TenantID
    LEFT OUTER JOIN bil_billheader_methodofpayments
        ON bil_billheader_methodofpayments.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
        AND bil_billheader_methodofpayments.Tenant_RefID = @TenantID
        AND bil_billheader_methodofpayments.IsDeleted = 0
        AND bil_billheader_methodofpayments.IsPreferredMethodOfPayment = 1
    LEFT OUTER JOIN acc_dun_dunningprocess_memberbills
        ON acc_dun_dunningprocess_memberbills.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
        AND acc_dun_dunningprocess_memberbills.Tenant_RefID = @TenantID
    WHERE
        (bil_billheaders.IsDeleted = 0 AND bil_billheaders.Tenant_RefID = @TenantID)
        AND (@BillStatusGlobalProperty IS NULL OR (@BillStatusGlobalProperty IS NOT NULL AND bil_billstatuses.GlobalPropertyMatchingID = @BillStatusGlobalProperty))
        AND (@BillNumber IS NULL OR (@BillNumber IS NOT NULL AND LOWER(bil_billheaders.BillNumber) LIKE CONCAT('%', LOWER(@BillNumber), '%')))
        AND (@Customer_NameOrNumber IS NULL OR
                (@Customer_NameOrNumber IS NOT NULL AND 
                    ( LOWER(cmn_bpt_ctm_customers.InternalCustomerNumber) LIKE CONCAT('%', LOWER(@Customer_NameOrNumber), '%') 
                        OR  LOWER(cmn_bpt_businessparticipants_customer.DisplayName) LIKE CONCAT('%', LOWER(@Customer_NameOrNumber), '%') 
                    )
                )
            )
        AND (@DeliveryDateFrom IS NULL OR (@DeliveryDateFrom IS NOT NULL AND log_shp_shipment_statushistory.Creation_Timestamp >= @DeliveryDateFrom))
        AND (@DeliveryDateTo IS NULL OR (@DeliveryDateTo IS NOT NULL AND log_shp_shipment_statushistory.Creation_Timestamp <= @DeliveryDateTo))
        AND (@DateOnBillFrom IS NULL OR (@DateOnBillFrom IS NOT NULL AND bil_billheaders.DateOnBill >= @DateOnBillFrom))
        AND (@DateOnBillTo IS NULL OR (@DateOnBillTo IS NOT NULL AND bil_billheaders.DateOnBill <= @DateOnBillTo))
        AND (@PaymentDeadlineFrom IS NULL OR (@PaymentDeadlineFrom IS NOT NULL AND (ADDDATE(bil_billheaders.DateOnBill, COALESCE(acc_pay_conditions.MaximumPaymentTreshold_InDays, 0))) >= @PaymentDeadlineFrom))
        AND (@PaymentDeadlineTo IS NULL OR (@PaymentDeadlineTo IS NOT NULL AND (ADDDATE(bil_billheaders.DateOnBill, COALESCE(acc_pay_conditions.MaximumPaymentTreshold_InDays, 0))) <= @PaymentDeadlineTo))
        AND (@BillPaymentTypeID IS NULL OR (bil_billheader_methodofpayments.ACC_PAY_Type_RefID = @BillPaymentTypeID))
        AND (@TotalValueFrom IS NULL OR (@TotalValueFrom IS NOT NULL AND bil_billheaders.TotalValue_BeforeTax >= @TotalValueFrom))
        AND (@TotalValueTo IS NULL OR (@TotalValueTo IS NOT NULL AND bil_billheaders.TotalValue_BeforeTax <= @TotalValueTo))
    GROUP BY bil_billheaders.BIL_BillHeaderID
    ) X 
    LEFT JOIN
    bil_billheader_assignedpayments On X.BIL_BillHeaderID = bil_billheader_assignedpayments.BIL_BillHeader_RefID 
    LEFT JOIN
    acc_bok_accounting_transactions
    On bil_billheader_assignedpayments.ACC_BOK_AccountingTransaction_RefID =
    acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID Left Join
    acc_bok_accounting_bookinglines
    On acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID =
    acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID
    Where
    (@TransactionDateFrom Is Null Or (@TransactionDateFrom Is Not Null And acc_bok_accounting_bookinglines.DateOfTransaction >= @TransactionDateFrom)) And
    (@TransactionDateTo Is Null Or (@TransactionDateTo Is Not Null And acc_bok_accounting_bookinglines.DateOfTransaction <= @TransactionDateTo))
Group By
  X.BIL_BillHeaderID
  