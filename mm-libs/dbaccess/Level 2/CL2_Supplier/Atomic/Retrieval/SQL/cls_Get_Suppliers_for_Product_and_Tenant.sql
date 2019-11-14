
	Select
	  cmn_bpt_suppliers.CMN_BPT_SupplierID,
	  cmn_bpt_businessparticipants.DisplayName
	From
	  cmn_pro_product_suppliers Right Join
	  cmn_bpt_suppliers On cmn_bpt_suppliers.CMN_BPT_SupplierID =
	    cmn_pro_product_suppliers.CMN_BPT_Supplier_RefID Left Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
	    cmn_bpt_suppliers.Ext_BusinessParticipant_RefID
	Where
	  cmn_pro_product_suppliers.CMN_PRO_Product_RefID = @ProductID And
	  cmn_pro_product_suppliers.Tenant_RefID = @TenantID And
	  cmn_pro_product_suppliers.IsDeleted = 0 And
	  cmn_bpt_suppliers.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsDeleted = 0
  