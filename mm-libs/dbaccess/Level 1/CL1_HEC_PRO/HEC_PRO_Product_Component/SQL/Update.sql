UPDATE 
	hec_pro_product_components
SET 
	HEC_PRO_Component_RefID=@HEC_PRO_Component_RefID,
	HEC_PRO_Product_RefID=@HEC_PRO_Product_RefID,
	ComponentNumber=@ComponentNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_PRO_Product_ComponentID = @HEC_PRO_Product_ComponentID