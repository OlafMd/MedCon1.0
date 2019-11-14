UPDATE 
	bil_billposition_2_product
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	LOG_ProductTrackingInstance_RefID=@LOG_ProductTrackingInstance_RefID,
	Quantity=@Quantity,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID