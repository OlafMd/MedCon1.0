UPDATE 
	ord_prc_rfp_potentialsuppliers
SET 
	RequestForProposal_Header_RefID=@RequestForProposal_Header_RefID,
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_RFP_PotentialSupplierID = @ORD_PRC_RFP_PotentialSupplierID