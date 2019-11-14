
	Select
	  cmn_pro_product_suppliers.CMN_PRO_Product_RefID,
	  cmn_pro_product_suppliers.ProcurementPrice_RefID,
	  cmn_price_values.PriceValue_Amount,
	  cmn_pro_product_suppliers.Tenant_RefID,
	  cmn_pro_product_suppliers.IsDeleted
	From
	  cmn_pro_product_suppliers Inner Join
	  cmn_price_values On cmn_pro_product_suppliers.ProcurementPrice_RefID =
	    cmn_price_values.Price_RefID
	Where
	  cmn_pro_product_suppliers.CMN_PRO_Product_RefID = @ProductIDList And
	  cmn_pro_product_suppliers.Tenant_RefID = @TenantID And
	  cmn_pro_product_suppliers.IsDeleted = 0
  