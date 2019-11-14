
	SELECT ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
		,ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID
		,ord_cuo_customerorderreturn_positions.Position_Quantity
		,ord_cuo_customerorderreturn_positions.Position_ValuePerUnit
    ,ord_cuo_customerorderreturn_positions.Position_ValueTotal
		,ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber
		,CAST((ord_cuo_customerorderreturn_positions.Position_ValuePerUnit / ord_cuo_customerorderreturn_positions.Position_Quantity) AS DECIMAL) AS ValuePerUnit
		,cmn_bpt_businessparticipants.DisplayName AS CustomerName
    ,cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    ,cmn_currencies.Symbol AS CurrencySymbol
    ,cmn_currencies.ISO4127 AS CurrencyISO
	FROM ord_cuo_customerorderreturn_positions
	INNER JOIN ord_cuo_customerorderreturn_headers ON ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID = ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID
		AND ord_cuo_customerorderreturn_headers.Tenant_RefID = @TenantID
		AND ord_cuo_customerorderreturn_headers.IsDeleted = 0
	INNER JOIN cmn_bpt_ctm_customers ON ord_cuo_customerorderreturn_headers.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID
		AND cmn_bpt_ctm_customers.Tenant_RefID = @TenantID
		AND cmn_bpt_ctm_customers.IsDeleted = 0
	INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
		AND cmn_bpt_businessparticipants.IsDeleted = 0
		AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
	LEFT OUTER JOIN bil_billposition_2_customerorderreturnposition ON bil_billposition_2_customerorderreturnposition.ORD_CUO_CustomerOrderReturn_Position_RefID = ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID
		AND bil_billposition_2_customerorderreturnposition.IsDeleted = 0
		AND bil_billposition_2_customerorderreturnposition.Tenant_RefID = @TenantID
  INNER JOIN cmn_currencies On ord_cuo_customerorderreturn_headers.Currency_RefID = cmn_currencies.CMN_CurrencyID
 		AND cmn_currencies.IsDeleted = 0
		AND cmn_currencies.Tenant_RefID = @TenantID 
	WHERE ord_cuo_customerorderreturn_positions.Tenant_RefID = @TenantID
		AND ord_cuo_customerorderreturn_positions.IsDeleted = 0
		AND bil_billposition_2_customerorderreturnposition.AssignmentID IS NULL
  