
	SELECT ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
		       ord_cuo_customerorder_headers.CustomerOrder_Number,
           ord_cuo_customerorder_headers.ProcurementOrderITL,
		       ord_cuo_customerorder_headers.CustomerOrder_Date,
		       ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID,
	         ord_cuo_customerorder_statuses.GlobalPropertyMatchingID,
	         ord_cuo_customerorder_statuses.Status_Code,
	         ord_cuo_customerorder_statuses.Status_Name_DictID,
		       ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID,
		       ord_cuo_customerorder_headers.CustomerOrder_Currency_RefID,
		       ord_cuo_customerorder_headers.TotalValue_BeforeTax,
		       cmn_bpt_businessparticipants.DisplayName as Customer_Name,
		       cmn_currencies.Name_DictID,
		       cmn_currencies.ISO4127,
		       cmn_currencies.Symbol,
	    	  (SELECT COUNT(ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID)
		       FROM ord_cuo_customerorder_positions
		      WHERE ord_cuo_customerorder_positions.CustomerOrder_Header_RefID= ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID
		      AND ord_cuo_customerorder_positions.Tenant_RefID = @TenantID
		      AND ord_cuo_customerorder_positions.IsDeleted = 0 ) AS Number_of_Positions
		FROM ord_cuo_customerorder_headers
		LEFT JOIN cmn_bpt_businessparticipants ON ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
		LEFT JOIN cmn_currencies ON ord_cuo_customerorder_headers.CustomerOrder_Currency_RefID = cmn_currencies.CMN_CurrencyID
		AND cmn_currencies.Tenant_RefID = @TenantID
		AND cmn_currencies.IsDeleted = 0
	  LEFT JOIN ord_cuo_customerorder_statuses
	        ON ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID =
	           ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID
	       AND   ord_cuo_customerorder_statuses.IsDeleted=0
	      AND ord_cuo_customerorder_statuses.Tenant_RefID=@TenantID
		WHERE ord_cuo_customerorder_headers.IsCustomerOrderFinalized = 0
		  AND ord_cuo_customerorder_headers.Tenant_RefID = @TenantID
		  AND ord_cuo_customerorder_headers.IsDeleted = 0
	    AND ord_cuo_customerorder_statuses.GlobalPropertyMatchingID=@StatusGlobalPropertyMatching

  