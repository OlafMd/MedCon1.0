
	Select
	  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID,
	  ord_prc_shoppingcart.IsProcurementOrderCreated,
	  cmn_str_offices.Office_InternalName,
	  cmn_str_offices.Office_InternalNumber,
	  ord_prc_shoppingcart.InternalIdentifier As ShoppingCartIdentifier
	From
	  ord_prc_shoppingcart Inner Join
	  ord_prc_office_shoppingcarts On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
	    ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID And
	    ord_prc_office_shoppingcarts.IsDeleted = 0 Inner Join
	  cmn_str_offices On ord_prc_office_shoppingcarts.CMN_STR_Office_RefID =
	    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0
	Where
	  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID = @ShoppingCartID And
	  ord_prc_shoppingcart.IsDeleted = 0 And
	  ord_prc_shoppingcart.Tenant_RefID = @TenantID
  