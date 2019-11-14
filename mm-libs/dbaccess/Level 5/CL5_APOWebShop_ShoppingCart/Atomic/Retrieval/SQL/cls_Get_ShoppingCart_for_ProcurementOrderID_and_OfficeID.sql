
	Select Distinct
	  ord_prc_shoppingcart.ORD_PRC_ShoppingCartID
	From
	  ord_prc_shoppingcart Inner Join
	  ord_prc_office_shoppingcarts
	    On ord_prc_office_shoppingcarts.ORD_PRC_ShoppingCart_RefID =
	    ord_prc_shoppingcart.ORD_PRC_ShoppingCartID Inner Join
	  ord_prc_shoppingcart_products On ord_prc_shoppingcart.ORD_PRC_ShoppingCartID =
	    ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_RefID Inner Join
	  ord_prc_shoppingcart_2_procurementorderposition
	    On
	    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ShoppingCart_Product_RefID = ord_prc_shoppingcart_products.ORD_PRC_ShoppingCart_ProductID Inner Join
	  ord_prc_procurementorder_positions
	    On
	    ord_prc_shoppingcart_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
	Where
	  ord_prc_office_shoppingcarts.CMN_STR_Office_RefID = @OfficeID And
	  ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
	  @ProcurementOrderID
  