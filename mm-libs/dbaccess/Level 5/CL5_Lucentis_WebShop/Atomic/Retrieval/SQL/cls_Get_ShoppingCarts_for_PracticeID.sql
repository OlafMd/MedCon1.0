
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_shoppingcart.InternalIdentifier,
  ord_prc_shoppingcart.Creation_Timestamp,
  ord_prc_shoppingcart.IsProcurementOrderCreated,
  ord_prc_procurementorder_headers.ProcurementOrder_Date,
  ord_prc_procurementorder_statuses.GlobalPropertyMatchingID As
  ProcStatusMatchingID,
  ord_prc_procurementorder_statushistory.StatusHistoryComment
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  ord_prc_shoppingcart On ord_prc_shoppingcart.CreatedBy_Account_RefID =
    hec_doctors.Account_RefID Inner Join
  ord_prc_office_shoppingcarts
    On ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID =
    ord_prc_shoppingcart.ORD_PRC_ShoppingCartID Inner Join
  cmn_str_offices On ord_prc_office_shoppingcarts.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Inner Join
  ord_prc_shoppingcart_products
    On ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID =
    ord_prc_shoppingcart.ORD_PRC_ShoppingCartID Inner Join
  ord_prc_shoppingcart_2_procurementorderposition
    On ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID =
    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ShoppingCart_Product_RefID Inner Join
  ord_prc_procurementorder_positions
    On
    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
    ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID
  Left Join
  ord_prc_procurementorder_statushistory
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID And
    ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_doctors.Tenant_RefID = @TenantID And
  ord_prc_shoppingcart.IsDeleted = 0 And
  cmn_str_offices.Office_InternalName = @PracticeBPID And
  ord_prc_office_shoppingcarts.IsDeleted = 0 And
  cmn_str_offices.IsDeleted = 0
Group By
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_procurementorder_statuses.GlobalPropertyMatchingID,
  ord_prc_procurementorder_statushistory.StatusHistoryComment
  