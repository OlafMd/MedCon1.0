
	SELECT
		  cmn_pro_products.CMN_PRO_ProductID,
		  cmn_pro_products.Product_Name_DictID,
		  cmn_pro_products.Product_Description_DictID,
		  cmn_pro_products.Product_Number,
		  hec_product_dosageforms.HEC_Product_DosageFormID,
		  hec_product_dosageforms.DosageForm_Name_DictID,
		  cmn_units.CMN_UnitID,
		  cmn_units.Label_DictID
		FROM
		  cmn_pro_products
		  LEFT JOIN hec_products
		    ON cmn_pro_products.CMN_PRO_ProductID = hec_products.Ext_PRO_Product_RefID AND
		       hec_products.IsDeleted = 0
		  LEFT JOIN hec_product_dosageforms
		    ON hec_products.ProductDosageForm_RefID =
		         hec_product_dosageforms.HEC_Product_DosageFormID AND
		       hec_product_dosageforms.IsDeleted = 0
		  LEFT JOIN cmn_pro_pac_packageinfo
		    ON cmn_pro_products.PackageInfo_RefID =
		         cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID AND
		       cmn_pro_pac_packageinfo.IsDeleted = 0
		  LEFT JOIN cmn_units
		    ON cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID = cmn_units.CMN_UnitID AND
		       cmn_units.IsDeleted = 0
		WHERE
		  cmn_pro_products.IsDeleted = 0 AND
		  cmn_pro_products.IsProduct_Article = 1 AND
		  cmn_pro_products.Tenant_RefID = @TenantID

  