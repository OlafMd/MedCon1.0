UPDATE 
	cmn_bpt_ctm_customer_2_salesrepresentatives
SET 
	SalesRepresentative_RefID=@SalesRepresentative_RefID,
	Customer_RefID=@Customer_RefID,
	IsPrimary_SalesRep=@IsPrimary_SalesRep,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID