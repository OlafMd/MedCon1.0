UPDATE 
	ord_prc_procurementorder_notes
SET 
	ORD_PRC_ProcurementOrder_Header_RefID=@ORD_PRC_ProcurementOrder_Header_RefID,
	ORD_PRC_ProcurementOrder_Position_RefID=@ORD_PRC_ProcurementOrder_Position_RefID,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	Comment=@Comment,
	Title=@Title,
	NotePublishDate=@NotePublishDate,
	SequenceOrderNumber=@SequenceOrderNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ProcurementOrder_NoteID = @ORD_PRC_ProcurementOrder_NoteID