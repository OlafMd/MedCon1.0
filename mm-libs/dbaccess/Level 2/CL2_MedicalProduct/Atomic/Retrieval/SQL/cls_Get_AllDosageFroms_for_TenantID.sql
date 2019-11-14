
	Select
	  hec_product_dosageforms.HEC_Product_DosageFormID,
	  hec_product_dosageforms.GlobalPropertyMatchingID,
	  hec_product_dosageforms.DosageForm_Name_DictID,
	  hec_product_dosageforms.DosageForm_Description_DictID
	From
	  hec_product_dosageforms
	Where
	  hec_product_dosageforms.IsDeleted = 0 And
	  hec_product_dosageforms.Tenant_RefID = @TenantID
  