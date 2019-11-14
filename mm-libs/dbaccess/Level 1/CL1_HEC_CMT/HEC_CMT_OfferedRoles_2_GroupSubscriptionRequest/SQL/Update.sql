UPDATE 
	hec_cmt_offeredroles_2_groupsubscriptionrequest
SET 
	HEC_CMT_OfferedRole_RefID=@HEC_CMT_OfferedRole_RefID,
	HEC_CMT_GroupSubscription_Request_RefID=@HEC_CMT_GroupSubscription_Request_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID