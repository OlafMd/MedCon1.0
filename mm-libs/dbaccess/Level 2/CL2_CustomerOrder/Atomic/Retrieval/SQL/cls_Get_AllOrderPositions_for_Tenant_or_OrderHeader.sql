
	Select
	  ord_cuo_customerorder_positions.CMN_PRO_Product_RefID,
	  cmn_pro_products.Product_Name_DictID,
	  ord_cuo_customerorder_positions.CustomerOrder_Header_RefID
	From
	  ord_cuo_customerorder_positions Left Join
	  cmn_pro_products On ord_cuo_customerorder_positions.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0 
	Where
	  ord_cuo_customerorder_positions.CustomerOrder_Header_RefID = IfNull (@OrderHeaderID, ord_cuo_customerorder_positions.CustomerOrder_Header_RefID)  And
	  ord_cuo_customerorder_positions.Tenant_RefID = @TenantID And
	  ord_cuo_customerorder_positions.IsDeleted = 0
  