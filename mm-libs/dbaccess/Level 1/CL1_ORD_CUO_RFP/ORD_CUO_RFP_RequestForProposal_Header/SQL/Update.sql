UPDATE 
	ord_cuo_rfp_requestforproposal_headers
SET 
	RequestingBusinessParticipant_RefID=@RequestingBusinessParticipant_RefID,
	RequestForProposalHeaderITPL=@RequestForProposalHeaderITPL,
	RequestForProposal_Number=@RequestForProposal_Number,
	DefaultCurrency_RefID=@DefaultCurrency_RefID,
	DateOfPublish=@DateOfPublish,
	ProposalDeadline=@ProposalDeadline,
	CompleteDeliveryUntillDate=@CompleteDeliveryUntillDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_RFO_RequestForProposal_HeaderID = @ORD_CUO_RFO_RequestForProposal_HeaderID