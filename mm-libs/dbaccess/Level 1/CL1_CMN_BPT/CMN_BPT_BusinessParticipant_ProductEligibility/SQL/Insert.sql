INSERT INTO 
	cmn_bpt_businessparticipant_producteligibility
	(
		CMN_BPT_BusinessParticipant_ProductEligibilityID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_BPT_BusinessParticipant_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_BusinessParticipant_ProductEligibilityID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_BPT_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)