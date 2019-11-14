
Select Distinct
  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
  ord_prc_shoppingcart.IsProcurementOrderCreated,
  ord_prc_shoppingcart.InternalIdentifier,
  ord_prc_shoppingcart.Creation_Timestamp As ShoppingCart_CreationDate,
  ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID As
  Status_GlobalPropertyMatchingID,
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_InternalName,
  ord_prc_procurementorder_headers.ProcurementOrder_Date,
  ord_prc_procurementorder_statuses.GlobalPropertyMatchingID As
  ProcurementOrderStatus,
  ord_prc_shoppingcartstatus_history.Creation_Timestamp,
  ord_prc_shoppingcart_statuses1.GlobalPropertyMatchingID,
  ord_prc_shoppingcart_statuses1.Creation_Timestamp As ApprovedDate
From
  ord_prc_shoppingcart Inner Join
  ord_prc_shoppingcart_statuses
    On ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID =
    ord_prc_shoppingcart_statuses.ORD_PRC_ShoppingCart_StatusID And
    ord_prc_shoppingcart_statuses.IsDeleted = 0 Inner Join
  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID And
    ord_prc_office_shoppingcarts.IsDeleted = 0 Left Join
  ord_prc_shoppingcart_products On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID And
    ord_prc_shoppingcart_products.IsDeleted = 0 And
    ord_prc_shoppingcart_products.IsCanceled = 0 Left Join
  cmn_pro_products On ord_prc_shoppingcart_products.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0
  Left Join
  cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
    cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0 Left Join
  ord_prc_shoppingcart_2_procurementorderposition
    On ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID =
    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ShoppingCart_Product_RefID And ord_prc_shoppingcart_2_procurementorderposition.IsDeleted = 0 Left Join
  ord_prc_procurementorder_positions
    On
    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.IsDeleted = 0 Left Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.IsDeleted = 0 Left Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.IsDeleted = 0 Inner Join
  cmn_str_offices On ord_prc_office_shoppingcarts.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0
  Inner Join
  cmn_bpt_emp_employee_2_office On cmn_str_offices.CMN_STR_OfficeID =
    cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID And
    cmn_bpt_emp_employee_2_office.IsDeleted = 0 Inner Join
  cmn_bpt_emp_employees
    On cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
    cmn_bpt_emp_employees.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    usr_accounts.IsDeleted = 0 And usr_accounts.USR_AccountID = @AccountID
  Left Join
  ord_prc_shoppingcartstatus_history
    On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
    ord_prc_shoppingcartstatus_history.ORD_PRC_ShoppingCart_RefID Inner Join
  ord_prc_shoppingcart_statuses ord_prc_shoppingcart_statuses1
    On ord_prc_shoppingcart_statuses1.ORD_PRC_ShoppingCart_StatusID =
    ord_prc_shoppingcartstatus_history.ORD_PRC_ShoppingCart_Status_RefID
Where
  ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID = @Status_GlobalPropertyMatchingID_List And
  ord_prc_shoppingcart.IsDeleted = 0 And
  ord_prc_shoppingcart.Tenant_RefID = @TenantID And
  (@NumberOfLastDays Is Not Null And
    ord_prc_shoppingcart.Creation_Timestamp > Date_Add(CurDate(), Interval
    -@NumberOfLastDays Day) Or
    @NumberOfLastDays Is Null Or
    ord_prc_shoppingcart.IsProcurementOrderCreated = 0) And
  (@ProductNameContains Is Null Or
    @ProductNameContains Is Not Null And
    Lower(cmn_pro_products_de.Content) Like Concat('%',
    Lower(@ProductNameContains), '%')) And
  ord_prc_shoppingcart_statuses1.GlobalPropertyMatchingID =
  @ApprovedGlobalPropertyID And
  ord_prc_shoppingcart_statuses1.Tenant_RefID = @TenantID
Order By
  ord_prc_shoppingcart.Creation_Timestamp Desc
	  
  