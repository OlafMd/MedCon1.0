
	Select
	  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
	  ord_cuo_customerorder_headers.CustomerOrder_Number,
	  cmn_universalcontactdetails.CompanyName_Line1 As OrderedByCompanyName,
	  cmn_universalcontactdetails.Contact_Email As OrderedByEmail,
    ord_cuo_customerorder_headers.CustomerOrder_Date,
	  Count(ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID) As
	  PositionCount,
	  Sum(ord_cuo_customerorder_positions.Position_ValueTotal * (1 +
	  acc_tax_taxes.TaxRate / 100)) As Price
	From
	  ord_cuo_customerorder_headers Inner Join
	  cmn_bpt_businessparticipants
	    On ord_cuo_customerorder_headers.OrderingCustomer_BusinessParticipant_RefID
	    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
	  cmn_com_companyinfo
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
	  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID Inner Join
	  ord_cuo_customerorder_positions
	    On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
	    ord_cuo_customerorder_positions.CustomerOrder_Header_RefID Inner Join
	  cmn_pro_product_salestaxassignmnets
	    On ord_cuo_customerorder_positions.CMN_PRO_Product_RefID =
	    cmn_pro_product_salestaxassignmnets.Product_RefID Inner Join
	  acc_tax_taxes On cmn_pro_product_salestaxassignmnets.ApplicableSalesTax_RefID
	    = acc_tax_taxes.ACC_TAX_TaxeID
	Where
	  ord_cuo_customerorder_headers.Tenant_RefID = @TenantID And
	  ord_cuo_customerorder_headers.IsDeleted = 0 And
	  ord_cuo_customerorder_headers.IsCustomerOrderFinalized = 0
	Group By
	  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID
	Order By
	  ord_cuo_customerorder_headers.CustomerOrder_Date Desc
  