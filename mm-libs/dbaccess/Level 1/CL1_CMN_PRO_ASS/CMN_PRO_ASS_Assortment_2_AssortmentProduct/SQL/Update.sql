UPDATE 
	cmn_pro_ass_assortment_2_assortmentproduct
SET 
	CMN_PRO_ASS_Assortment_RefID=@CMN_PRO_ASS_Assortment_RefID,
	CMN_PRO_ASS_Assortment_Product_RefID=@CMN_PRO_ASS_Assortment_Product_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID