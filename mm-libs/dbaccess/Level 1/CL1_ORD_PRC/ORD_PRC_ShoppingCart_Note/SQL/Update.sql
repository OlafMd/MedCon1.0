UPDATE 
	ord_prc_shoppingcart_notes
SET 
	ORD_PRC_ShoppingCart_RefID=@ORD_PRC_ShoppingCart_RefID,
	CMN_BPT_Memo_RefID=@CMN_BPT_Memo_RefID,
	IsNoteForProcurementOrder=@IsNoteForProcurementOrder,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ShoppingCart_NoteID = @ORD_PRC_ShoppingCart_NoteID