UPDATE 
	cmn_ctr_contract_parties
SET 
	Contract_RefID=@Contract_RefID,
	Undersigning_BusinessParticipant_RefID=@Undersigning_BusinessParticipant_RefID,
	Party_ContractRole_RefID=@Party_ContractRole_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CTR_Contract_PartyID = @CMN_CTR_Contract_PartyID