
	SELECT
	  ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID,
	  ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber,
	  ord_cuo_customerorderreturn_headers.Creation_Timestamp,
	  ord_cuo_customerorderreturn_headers.Creation_Timestamp AS OrderDate,
	  ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID,
	  ord_cuo_customerorderreturn_positions.Position_ValueTotal,
	  cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID,
	  cmn_bpt_ctm_customers.InternalCustomerNumber,
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AS CustomerBusinessParticipantID,
	  cmn_bpt_businessparticipants.DisplayName AS CustomerName,
	  cmn_currencies.Symbol AS CurrencySymbol,
	  acc_tax_taxes.TaxRate
	FROM ord_cuo_customerorderreturn_headers
	INNER JOIN ord_cuo_customerorderreturn_positions
	  ON ord_cuo_customerorderreturn_positions.CustomerOrderReturnHeader_RefID = ord_cuo_customerorderreturn_headers.ORD_CUO_CustomerOrderReturn_HeaderID
	  AND ord_cuo_customerorderreturn_positions.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND ord_cuo_customerorderreturn_positions.IsDeleted = 0
	INNER JOIN cmn_bpt_ctm_customers
	  ON cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID = ord_cuo_customerorderreturn_headers.Customer_RefID
	  AND cmn_bpt_ctm_customers.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND cmn_bpt_ctm_customers.IsDeleted = 0 
	INNER JOIN cmn_bpt_businessparticipants
	  ON cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID
	  AND cmn_bpt_businessparticipants.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND cmn_bpt_businessparticipants.IsDeleted = 0 
	LEFT JOIN bil_billposition_2_customerorderreturnposition
	  ON bil_billposition_2_customerorderreturnposition.ORD_CUO_CustomerOrderReturn_Position_RefID = ord_cuo_customerorderreturn_positions.ORD_CUO_CustomerOrderReturn_PositionID
	  AND bil_billposition_2_customerorderreturnposition.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND bil_billposition_2_customerorderreturnposition.IsDeleted = 0 
	LEFT JOIN cmn_sls_prices
	  ON cmn_sls_prices.CMN_PRO_Product_RefID = ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID
	  AND cmn_sls_prices.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND cmn_sls_prices.IsDeleted = 0
	LEFT JOIN cmn_currencies
	  ON cmn_currencies.CMN_CurrencyID = cmn_sls_prices.CMN_Currency_RefID
	  AND cmn_currencies.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND cmn_currencies.IsDeleted = 0
	LEFT JOIN cmn_pro_product_salestaxassignmnets 
	  ON cmn_pro_product_salestaxassignmnets.Product_RefID = ord_cuo_customerorderreturn_positions.CMN_PRO_Product_RefID
	  AND cmn_pro_product_salestaxassignmnets.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND cmn_pro_product_salestaxassignmnets.IsDeleted = 0
	LEFT JOIN acc_tax_taxes
	  ON acc_tax_taxes.ACC_TAX_TaxeID = cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
	  AND acc_tax_taxes.Tenant_RefID = ord_cuo_customerorderreturn_headers.Tenant_RefID
	  AND acc_tax_taxes.IsDeleted = 0
	WHERE
	  ord_cuo_customerorderreturn_headers.Tenant_RefID = @TenantID
	  AND ord_cuo_customerorderreturn_headers.IsDeleted = 0
	  AND bil_billposition_2_customerorderreturnposition.AssignmentID IS NULL
	  AND (@OrderNumber IS NULL OR (@OrderNumber IS NOT NULL AND ord_cuo_customerorderreturn_headers.CustomerOrderReturnNumber LIKE CONCAT('%', @OrderNumber, '%')))
	  AND (@Customer IS NULL OR (@Customer IS NOT NULL AND LOWER(cmn_bpt_businessparticipants.DisplayName) LIKE LOWER(CONCAT('%', @Customer, '%'))))
	  AND (@PeriodFrom IS NULL OR (@PeriodFrom IS NOT NULL AND ord_cuo_customerorderreturn_headers.Creation_Timestamp >= @PeriodFrom))
	  AND (@PeriodTo IS NULL OR (@PeriodTo IS NOT NULL AND ord_cuo_customerorderreturn_headers.Creation_Timestamp <= @PeriodTo));
  