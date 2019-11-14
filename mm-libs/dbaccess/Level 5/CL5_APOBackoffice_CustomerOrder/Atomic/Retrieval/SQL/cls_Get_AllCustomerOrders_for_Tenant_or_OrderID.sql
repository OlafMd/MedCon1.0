
Select
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  cmn_universalcontactdetails.CompanyName_Line1,
  cmn_universalcontactdetails.Contact_Email,
  ord_cuo_customerorder_headers.CustomerOrder_Date,
  ord_cuo_customerorder_headers.TotalValue_BeforeTax,
  ord_cuo_customerorder_statuses.Status_Code,
  ord_cuo_customerorder_statuses.Status_Name_DictID,
  ord_cuo_customerorder_statuses.GlobalPropertyMatchingID as CustomerOrderStatus_GlobalPropertyMatching,
  Order_createdBy.DisplayName AS CreatedBy_DisplayName,
  ord_cuo_customerorder_headers.CreatedBy_BusinessParticipant_RefID
From
  ord_cuo_customerorder_headers Inner Join
  cmn_bpt_businessparticipants
    On ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID Inner Join
  ord_cuo_customerorder_statushistory
    On ord_cuo_customerorder_statushistory.CustomerOrder_Header_RefID =
    ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID And
    ord_cuo_customerorder_statushistory.IsDeleted = 0 Inner Join
  ord_cuo_customerorder_statuses
    On ord_cuo_customerorder_statushistory.CustomerOrder_Status_RefID =
    ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID And
    ord_cuo_customerorder_statushistory.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants Order_createdBy
    On ord_cuo_customerorder_headers.CreatedBy_BusinessParticipant_RefID =
    Order_createdBy.CMN_BPT_BusinessParticipantID
Where
  (@OrderID IS NULL OR @OrderID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID) And
  cmn_bpt_businessparticipants.IsCompany = True And
  ord_cuo_customerorder_headers.Tenant_RefID = @TenantID And
  ord_cuo_customerorder_headers.IsDeleted = 0
  