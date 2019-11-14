
	Select
		hec_doctor_requiredproduct.HEC_Doctor_RefID,
		cmn_pro_products.CMN_PRO_ProductID
	From
		cmn_pro_products Inner Join
		hec_doctor_requiredproduct On hec_doctor_requiredproduct.CMN_PRO_Product_RefID
			= cmn_pro_products.CMN_PRO_ProductID
	Where
		cmn_pro_products.Tenant_RefID = @TennantID And
		cmn_pro_products.IsDeleted = 0 And
		hec_doctor_requiredproduct.IsDeleted = 0 And
		cmn_pro_products.CMN_PRO_ProductID = @ProductID
	