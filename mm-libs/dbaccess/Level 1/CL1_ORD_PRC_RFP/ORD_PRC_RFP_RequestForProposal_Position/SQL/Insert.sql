INSERT INTO 
	ord_prc_rfp_requestforproposal_positions
	(
		ORD_PRC_RFP_RequestForProposal_PositionID,
		RequestForProposalPositionITPL,
		RequestForProposal_Header_RefID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_PRO_Product_Release_RefID,
		Quantity,
		IsReplacementPermitted,
		OrderSequence,
		DeliveryUntillDate,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_RFP_RequestForProposal_PositionID,
		@RequestForProposalPositionITPL,
		@RequestForProposal_Header_RefID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_PRO_Product_Release_RefID,
		@Quantity,
		@IsReplacementPermitted,
		@OrderSequence,
		@DeliveryUntillDate,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)