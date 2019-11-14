UPDATE 
	hec_pro_component_productapplications
SET 
	HEC_PRO_Component_RefID=@HEC_PRO_Component_RefID,
	SequenceNumber=@SequenceNumber,
	IsPreparationNeccessaryBeforeApplication=@IsPreparationNeccessaryBeforeApplication,
	ApplicationMatterState=@ApplicationMatterState,
	ApplicationKindState=@ApplicationKindState,
	ProductApplicationLocation=@ProductApplicationLocation,
	ProductApplicationMethod=@ProductApplicationMethod,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_PRO_Component_ProductApplicationID = @HEC_PRO_Component_ProductApplicationID