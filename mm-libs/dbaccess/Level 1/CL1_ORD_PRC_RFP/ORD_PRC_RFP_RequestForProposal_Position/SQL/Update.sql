UPDATE 
	ord_prc_rfp_requestforproposal_positions
SET 
	RequestForProposalPositionITPL=@RequestForProposalPositionITPL,
	RequestForProposal_Header_RefID=@RequestForProposal_Header_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	Quantity=@Quantity,
	IsReplacementPermitted=@IsReplacementPermitted,
	OrderSequence=@OrderSequence,
	DeliveryUntillDate=@DeliveryUntillDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_RFP_RequestForProposal_PositionID = @ORD_PRC_RFP_RequestForProposal_PositionID