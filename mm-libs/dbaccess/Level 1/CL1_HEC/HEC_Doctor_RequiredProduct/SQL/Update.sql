UPDATE 
	hec_doctor_requiredproduct
SET 
	HEC_Doctor_RefID=@HEC_Doctor_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Doctor_RequiredProductID = @HEC_Doctor_RequiredProductID