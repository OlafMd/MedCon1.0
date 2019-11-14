UPDATE 
	cmn_pro_product_release_2_developertask
SET 
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	TMS_PRO_DeveloperTask_RefID=@TMS_PRO_DeveloperTask_RefID,
	IsDeleted=@IsDeleted,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID