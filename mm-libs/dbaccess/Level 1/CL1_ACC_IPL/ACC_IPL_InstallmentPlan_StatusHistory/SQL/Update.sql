UPDATE 
	acc_ipl_installmentplan_statushistory
SET 
	ACC_IPL_InstallmentPlan_RefID=@ACC_IPL_InstallmentPlan_RefID,
	ACC_IPL_InstallmentPlan_Status_RefID=@ACC_IPL_InstallmentPlan_Status_RefID,
	PerformedBy_BusinessParticipant_RefID=@PerformedBy_BusinessParticipant_RefID,
	StatusHistoryComment=@StatusHistoryComment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_IPL_InstallmentPlan_StatusHistoryID = @ACC_IPL_InstallmentPlan_StatusHistoryID