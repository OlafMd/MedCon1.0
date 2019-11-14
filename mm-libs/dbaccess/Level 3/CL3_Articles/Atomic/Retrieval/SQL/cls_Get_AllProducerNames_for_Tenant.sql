
	SELECT 
  DISTINCT (cmn_bpt_businessparticipants.DisplayName) DisplayName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID ProducerID
	FROM cmn_pro_products
	INNER JOIN cmn_bpt_businessparticipants ON cmn_bpt_businessparticipants.cmn_bpt_businessParticipantID = cmn_pro_products.ProducingBusinessParticipant_RefID
	WHERE cmn_pro_products.Tenant_RefID = @TenantID
  