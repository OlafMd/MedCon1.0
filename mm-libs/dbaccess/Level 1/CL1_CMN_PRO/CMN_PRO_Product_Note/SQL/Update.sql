UPDATE 
	cmn_pro_product_notes
SET 
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	IsImportant=@IsImportant,
	NoteContent=@NoteContent,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Product_NoteID = @CMN_PRO_Product_NoteID