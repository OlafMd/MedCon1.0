UPDATE 
	ord_cuo_customerorder_statushistory
SET 
	CustomerOrder_Header_RefID=@CustomerOrder_Header_RefID,
	CustomerOrder_Status_RefID=@CustomerOrder_Status_RefID,
	StatusHistoryComment=@StatusHistoryComment,
	PerformedBy_BusinessParticipant_RefID=@PerformedBy_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrder_StatusHistoryID = @ORD_CUO_CustomerOrder_StatusHistoryID