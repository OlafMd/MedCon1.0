
	Select
	  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID,
	  log_rcp_receipt_headers.ReceiptNumber,
	  cmn_universalcontactdetails.CompanyName_Line1
	From
	  log_rcp_receipt_headers Inner Join
	  cmn_bpt_suppliers On log_rcp_receipt_headers.ProvidingSupplier_RefID =
	    cmn_bpt_suppliers.CMN_BPT_SupplierID And cmn_bpt_suppliers.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_com_companyinfo
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID And
	    cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_universalcontactdetails On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
	    cmn_com_companyinfo.Contact_UCD_RefID And
	    cmn_universalcontactdetails.Tenant_RefID = @TenantID And
	    cmn_universalcontactdetails.IsDeleted = 0
	Where
	  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = @HeaderID And
	  log_rcp_receipt_headers.Tenant_RefID = @TenantID And
	  log_rcp_receipt_headers.IsDeleted = 0
  