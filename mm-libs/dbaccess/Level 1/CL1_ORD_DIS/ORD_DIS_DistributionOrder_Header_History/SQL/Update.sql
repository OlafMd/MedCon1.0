UPDATE 
	ord_dis_distributionorder_header_history
SET 
	DistributionOrder_Header_RefID=@DistributionOrder_Header_RefID,
	TriggeredBy_BusinessParticipant_RefID=@TriggeredBy_BusinessParticipant_RefID,
	IsCreated=@IsCreated,
	IsModified=@IsModified,
	IsCanceled=@IsCanceled,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_DIS_DistributionOrder_Header_HistoryID = @ORD_DIS_DistributionOrder_Header_HistoryID