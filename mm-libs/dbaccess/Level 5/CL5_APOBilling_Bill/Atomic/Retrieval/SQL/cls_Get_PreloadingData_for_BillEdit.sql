
Select
  bil_billheaders.BIL_BillHeaderID,
  bil_billheaders.BillRecipient_BuisnessParticipant_RefID,
  bil_billheaders.CreatedBy_BusinessParticipant_RefID,
  bil_billheaders.BillNumber,
  bil_billheaders.BillComment,
  bil_billheaders.BillHeader_PaymentCondition_RefID,
  bil_billheader_methodofpayments.ACC_PAY_Type_RefID,
  bil_billheaders.DateOnBill,
  bil_billheaders.BillingAddress_UCD_RefID,
  bil_billheader_2_billstatus.IsCurrentStatus,
  bil_billstatuses.BIL_BillStatusID,
  bil_billstatuses.GlobalPropertyMatchingID As Status_GlobalPropertyMatchingID,
  bil_billstatuses.BillStatus_Name_DictID,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.First_Name,
  cmn_universalcontactdetails.Last_Name,
  cmn_universalcontactdetails.Country_Name,
  cmn_universalcontactdetails.Country_639_1_ISOCode,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  bil_billheaders.Tenant_RefID,
  bil_billheaders.TotalValue_BeforeTax,
  bil_billheaders.TotalValue_IncludingTax,
  bil_billheader_2_billstatus.AssignmentID As Status_AssignmentID,
  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
  cmn_currencies.Symbol,
  cmn_currencies.ISO4127,
  COUNT(DISTINCT bil_notes.BIL_Note) NotesNumber
From
  bil_billheaders Inner Join
  bil_billheader_2_billstatus On bil_billheaders.BIL_BillHeaderID =
    bil_billheader_2_billstatus.BIL_BillHeader_RefID Inner Join
  bil_billstatuses On bil_billheader_2_billstatus.BIL_BillStatus_RefID =
    bil_billstatuses.BIL_BillStatusID Inner Join
  cmn_universalcontactdetails On bil_billheaders.BillingAddress_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID Inner Join
  cmn_bpt_ctm_customers
    On bil_billheaders.BillRecipient_BuisnessParticipant_RefID =
    cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID 
  Left Outer Join bil_billheader_methodofpayments
    On bil_billheader_methodofpayments.BIL_BillHeader_RefID =
    bil_billheaders.BIL_BillHeaderID And
    bil_billheader_methodofpayments.IsPreferredMethodOfPayment = 1 And
    bil_billheader_methodofpayments.IsDeleted = 0 Inner Join
  cmn_currencies On bil_billheaders.Currency_RefID =
    cmn_currencies.CMN_CurrencyID
  LEFT JOIN bil_notes ON bil_notes.BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
   AND bil_notes.IsDeleted = 0
Where
  bil_billheaders.BIL_BillHeaderID = @BillHeaderID And
  bil_billheaders.Tenant_RefID = @TenantID
  