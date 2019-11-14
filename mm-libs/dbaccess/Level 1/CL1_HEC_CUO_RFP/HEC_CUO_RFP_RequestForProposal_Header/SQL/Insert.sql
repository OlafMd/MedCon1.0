INSERT INTO 
	hec_cuo_rfp_requestforproposal_headers
	(
		HEC_CUO_RFP_RequestForProposal_HeaderID,
		Ext_ORD_CUO_RFP_RequestForProposal_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_CUO_RFP_RequestForProposal_HeaderID,
		@Ext_ORD_CUO_RFP_RequestForProposal_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)