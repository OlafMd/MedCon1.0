INSERT INTO 
	ord_cuo_rfp_requestforproposal_headers
	(
		ORD_CUO_RFO_RequestForProposal_HeaderID,
		RequestingBusinessParticipant_RefID,
		RequestForProposalHeaderITPL,
		RequestForProposal_Number,
		DefaultCurrency_RefID,
		DateOfPublish,
		ProposalDeadline,
		CompleteDeliveryUntillDate,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_CUO_RFO_RequestForProposal_HeaderID,
		@RequestingBusinessParticipant_RefID,
		@RequestForProposalHeaderITPL,
		@RequestForProposal_Number,
		@DefaultCurrency_RefID,
		@DateOfPublish,
		@ProposalDeadline,
		@CompleteDeliveryUntillDate,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)