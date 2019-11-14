
    	SELECT DISTINCT
		  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
		  ord_prc_shoppingcart.IsProcurementOrderCreated,
	    ord_prc_shoppingcart.InternalIdentifier,
		  ord_prc_shoppingcart.Creation_Timestamp AS ShoppingCart_CreationDate,
      ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID as Status_GlobalPropertyMatchingID,
		  cmn_str_offices.CMN_STR_OfficeID,
		  cmn_str_offices.Office_Name_DictID,
	    cmn_str_offices.Office_InternalName,
		  ord_prc_procurementorder_headers.ProcurementOrder_Date,
      ord_prc_procurementorder_statuses.GlobalPropertyMatchingID aS ProcurementOrderStatus
		FROM
		  ord_prc_shoppingcart
      INNER JOIN ord_prc_shoppingcart_statuses
        ON ord_prc_shoppingcart.ShoppingCart_CurrentStatus_RefID = ord_prc_shoppingcart_statuses.ORD_PRC_ShoppingCart_StatusID
        AND ord_prc_shoppingcart_statuses.IsDeleted = 0
		  INNER JOIN ord_prc_office_shoppingcarts
		    ON ord_prc_shoppingcart.ORD_PRC_ShoppingCartID = ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID AND
		       ord_prc_office_shoppingcarts.IsDeleted = 0
		  LEFT JOIN ord_prc_shoppingcart_products    
		    ON ord_prc_shoppingcart.ORD_PRC_ShoppingCartID = ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID
		    AND ord_prc_shoppingcart_products.IsDeleted = 0
		    AND ord_prc_shoppingcart_products.IsCanceled = 0
      LEFT JOIN cmn_pro_products
        ON ord_prc_shoppingcart_products.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
        AND cmn_pro_products.IsDeleted = 0
      LEFT JOIN cmn_pro_products_de
        ON cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID
        AND cmn_pro_products_de.IsDeleted = 0
		  LEFT JOIN ord_prc_shoppingcart_2_procurementorderposition
		    ON ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID = ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ShoppingCart_Product_RefID AND
		       ord_prc_shoppingcart_2_procurementorderposition.IsDeleted = 0
		  LEFT JOIN ord_prc_procurementorder_positions
		    ON ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID =ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID AND
		       ord_prc_procurementorder_positions.IsDeleted = 0
		  LEFT JOIN ord_prc_procurementorder_headers
		    ON ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID AND
		       ord_prc_procurementorder_headers.IsDeleted = 0
      LEFT JOIN ord_prc_procurementorder_statuses
        ON ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID = ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID
        AND ord_prc_procurementorder_statuses.IsDeleted = 0
		  INNER JOIN cmn_str_offices
		    ON ord_prc_office_shoppingcarts.CMN_STR_Office_RefID = cmn_str_offices.CMN_STR_OfficeID AND
		       cmn_str_offices.IsDeleted = 0
      INNER JOIN cmn_bpt_emp_employee_2_office
        ON cmn_str_offices.CMN_STR_OfficeID = cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID AND
           cmn_bpt_emp_employee_2_office.IsDeleted = 0
      INNER JOIN cmn_bpt_emp_employees
        ON cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID = cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID AND
           cmn_bpt_emp_employees.IsDeleted = 0
      INNER JOIN cmn_bpt_businessparticipants
        ON cmn_bpt_emp_employees.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AND
           cmn_bpt_businessparticipants.IsDeleted = 0
      INNER JOIN usr_accounts
        ON usr_accounts.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
        AND usr_accounts.IsDeleted = 0
        AND usr_accounts.USR_AccountID = @AccountID
		WHERE
		  ord_prc_shoppingcart.IsDeleted = 0 
		  AND ord_prc_shoppingcart.Tenant_RefID = @TenantID 
      AND (@NumberOfLastDays IS NOT NULL 
           AND ord_prc_shoppingcart.Creation_Timestamp > date_add(curdate(), INTERVAL - @NumberOfLastDays DAY)
           OR @NumberOfLastDays IS NULL 
           OR ord_prc_shoppingcart.IsProcurementOrderCreated = 0)
      AND ord_prc_shoppingcart_statuses.GlobalPropertyMatchingID = @Status_GlobalPropertyMatchingID_List
      AND (@ProductNameContains IS NULL OR @ProductNameContains IS NOT NULL AND LOWER(cmn_pro_products_de.Content) LIKE CONCAT('%', LOWER(@ProductNameContains), '%'))
	  ORDER BY ord_prc_shoppingcart.Creation_Timestamp DESC
	  
  