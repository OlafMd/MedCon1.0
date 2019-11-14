UPDATE 
	ord_cuo_customerorder_notes
SET 
	CustomerOrder_Header_RefID=@CustomerOrder_Header_RefID,
	CustomerOrder_Position_RefID=@CustomerOrder_Position_RefID,
	CMN_BPT_CTM_OrganizationalUnit_RefID=@CMN_BPT_CTM_OrganizationalUnit_RefID,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	Title=@Title,
	Comment=@Comment,
	NotePublishDate=@NotePublishDate,
	SequenceOrderNumber=@SequenceOrderNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrder_NoteID = @ORD_CUO_CustomerOrder_NoteID